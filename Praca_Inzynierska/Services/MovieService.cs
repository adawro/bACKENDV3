using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.Persistence;
using Praca_Inzynierska.Services.Communication;
using Praca_Inzynierska.Services.Interfaces;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _userName;
        private readonly IImageMovieService _imagesService;

        public MovieService(IMapper mapper, IHttpContextAccessor httpContext, AppDbContext context, IImageMovieService imagesService)
        {
            _mapper = mapper;
            _context = context;
            _userName = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            _imagesService = imagesService;
        }

        public MovieResponse AddMovie(MovieSaveDto movie)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new MovieResponse(errors);
            }

            if (user.Rola != "admin" && user.Rola != "moderator")
            {
                errors.Add("User", new[] { "Nie masz dostepu do tej czesci serwisu" });
                return new MovieResponse(errors);
            }

            Models.Type type = _context.Types.FirstOrDefault(t => t.Name == movie.Type);
            if (type == null)
            {
                errors.Add("TypeName", new[] { "Gatunek filmu o takiej nazwie nie istnieje" });
                return new MovieResponse(errors);
            }

            List<string> ActorNames = new List<string>();
            MovieReturnDto movieReturn = new MovieReturnDto();

            Movie movieSave = _mapper.Map<MovieSaveDto, Movie>(movie);
            movieSave.Type = type;

            List<MovieToActors> actorListSave = new List<MovieToActors>();

            List<ActorInFilm> actorListReturn = new List<ActorInFilm>();

            if(movie.Actors == null)
            {
                errors.Add("Actors", new[] { "Lista aktorów nie może być pusta" });
                return new MovieResponse(errors);
            }

            foreach (var e in movie.Actors)
            {
                Actor tmp = _context.Actors.FirstOrDefault(a => a.ActorId == e.ActorId);
                if (tmp == null)
                {
                    errors.Add(e.ActorId.ToString(), new[] { "Aktor o id = " + e.ActorId + " nie istnieje" });
                    continue;
                }
                string namer = tmp.Name + " " + tmp.Surname;
                MovieToActors actor = new MovieToActors { MovieId = movieSave.MovieId, Actor = e.ActorId, ActorNameInMovie = e.NameInFilm };
                actorListSave.Add(actor);
                ActorNames.Add(e.NameInFilm);
                ActorInFilm actorInFilm = new ActorInFilm
                {
                    NameSurname = namer,
                    NameSurnameInFilm = e.NameInFilm
                };
                actorListReturn.Add(actorInFilm);
            }

            if (errors == null)
            {
                return new MovieResponse(errors);
            }
            movieSave.Actors = actorListSave;

            List<ImageMovie> uploadedImagesModels = new List<ImageMovie>();
            if (movie.Images != null)
                try
                {
                    uploadedImagesModels =
                        _imagesService.UploadImagesToServer(movie.Images, movieSave);
                }
                catch (Exception ex)
                {
                    errors.Add("Images", new[] { ex.Message });
                    return new MovieResponse(errors);
                }

            movieSave.Images = uploadedImagesModels;

            _context.MoviesToActor.AddRange(actorListSave);
            _context.Movies.Add(movieSave);
            _context.MovieImages.AddRange(uploadedImagesModels);
            _context.SaveChanges();

            movieReturn = _mapper.Map<Movie, MovieReturnDto>(movieSave);
            movieReturn.Actors = actorListReturn;

            return new MovieResponse(movieReturn);
        }

        public MovieResponse EditMovie(int id, MovieEditDto movie)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new MovieResponse(errors);
            }

            if (user.Rola != "admin" && user.Rola != "moderator")
            {
                errors.Add("User", new[] { "Nie masz dostepu do tej czesci serwisu" });
                return new MovieResponse(errors);
            }

            Models.Type type = _context.Types.FirstOrDefault(t => t.Name == movie.Type);
            if (type == null)
            {
                errors.Add("TypeName", new[] { "Gatunek filmu o takiej nazwie nie istnieje" });
                return new MovieResponse(errors);
            }

            List<string> ActorNames = new List<string>();
            MovieReturnDto movieReturn = new MovieReturnDto();

            Movie movieSave = _mapper.Map<MovieEditDto, Movie>(movie);
            movieSave.Type = type;

            List<MovieToActors> actorListSave = new List<MovieToActors>();

            List<ActorInFilm> actorListReturn = new List<ActorInFilm>();

            if (movie.ActorsRemove !=null)
            {
                foreach (var e in movie.ActorsRemove)
                {
                    var tmp = _context.MoviesToActor.FirstOrDefault(a => a.Actor == e && a.MovieId == id);
                    try
                    {
                        _context.MoviesToActor.Remove(tmp);
                    }
                    catch (Exception ex)
                    {

                        errors.Add("ActorsRemove", new[] { ex.Message });
                        return new MovieResponse(errors);
                    }
                }
                _context.SaveChanges();
            }
            
            foreach (var e in movie.ActorsAdd)
            {
                Actor tmp = _context.Actors.FirstOrDefault(a => a.ActorId == e.ActorId);
                string namer = tmp.Name + " " + tmp.Surname;
                if (tmp == null)
                {
                    errors.Add(e.ActorId.ToString(), new[] { "Aktor o id = " + e.ActorId + " nie istnieje" });
                    continue;
                }
                var tmpp = _context.MoviesToActor.FirstOrDefault(a => a.Actor == e.ActorId && a.MovieId == id);
                if (tmpp != null)
                {
                    ActorInFilm existActor = new ActorInFilm
                    {
                        NameSurname = namer,
                        NameSurnameInFilm = e.NameInFilm
                    };
                    actorListReturn.Add(existActor);
                    continue;
                }
               
                MovieToActors actorSave = new MovieToActors { MovieId = movieSave.MovieId, Actor = e.ActorId, ActorNameInMovie = e.NameInFilm };
                actorListSave.Add(actorSave);
                ActorNames.Add(e.NameInFilm);
                ActorInFilm actorInFilm = new ActorInFilm
                {
                    NameSurname = namer,
                    NameSurnameInFilm = e.NameInFilm
                };
                actorListReturn.Add(actorInFilm);
            }
            
            if (errors == null)
            {
                return new MovieResponse(errors);
            }
            movieSave.Actors = actorListSave;

            var listImageRemove = new List<ImageMovie>();
            if (movie.RemoveImages != null)
                foreach (var fileName in movie.RemoveImages)
                {
                    var image = _context.ActorImages.FirstOrDefault(i => i.FileName == fileName);

                    if (image != null) _imagesService.RemoveImages(movie.RemoveImages);

                }

            List<ImageMovie> uploadedImagesModels = new List<ImageMovie>();
            if (movie.Images != null)
                try
                {
                    uploadedImagesModels =
                        _imagesService.UploadImagesToServer(movie.Images, movieSave);
                }
                catch (Exception ex)
                {
                    errors.Add("Images", new[] { ex.Message });
                    return new MovieResponse(errors);
                }

            movieSave.Images = uploadedImagesModels;
            movieSave.MovieId = id;
            _context.MovieImages.RemoveRange(listImageRemove);
            _context.MovieImages.AddRange(uploadedImagesModels);
            _context.MoviesToActor.AddRange(actorListSave);
            _context.Movies.Update(movieSave);
            _context.MovieImages.AddRange(uploadedImagesModels);
            _context.SaveChanges();

            movieReturn = _mapper.Map<Movie, MovieReturnDto>(movieSave);
            movieReturn.Actors = actorListReturn;

            return new MovieResponse(movieReturn);
        }

        public MovieListResponse FindMovie(string movieTitle)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            var movie = _context.Movies.Where(m => m.Title.Contains(movieTitle));

            if(movie==null)
            {
                errors.Add("Movie", new[] { "Nie istanieje taki film" });
                return new MovieListResponse(errors);
            }

            List<MovieReturnForList> movies = new List<MovieReturnForList>();

            foreach (var item in movie)
            {
                MovieReturnForList movieReturn = new MovieReturnForList
                {
                    Title = item.Title,
                    MovieId = item.MovieId,
                    ReleaseDate = item.ReleaseDate.Year,
                    WrittenBy = item.WrittenBy,
                    DirectionBy = item.DirectionBy
                };
                movies.Add(movieReturn);
            }
            MovieListReturnDto moviesReturn = new MovieListReturnDto { Movies = movies };
            return new MovieListResponse(moviesReturn);
        }

        public MovieReturnForActor FindMoviesForActor(int id)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            Actor actor = _context.Actors.FirstOrDefault(a => a.ActorId == id);
            MovieReturnForListDto tmp = new MovieReturnForListDto();
            MovieReturnForActor movieReturn = new MovieReturnForActor
            {
                Movies = new List<MovieReturnForListDto>()
            };
            foreach (var e in _context.MoviesToActor.Where(a => a.Actor == id))
            {
                var movie = _context.Movies.FirstOrDefault(m => m.MovieId == e.MovieId);
                tmp = _mapper.Map<Movie, MovieReturnForListDto>(movie);
                tmp.ActorNameInMovie = e.ActorNameInMovie;
                movieReturn.Movies.Add(tmp);
            }
            return movieReturn;
        }

        public MovieResponse MovieDetails(int id)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                errors.Add("Movie", new[] { "Nie istanieje taki film" });
                return new MovieResponse(errors);
            }
            Models.Type type = _context.Types.FirstOrDefault(t => t.TypeId == movie.TypeId);

            MovieReturnDto movieReturn = _mapper.Map<Movie, MovieReturnDto>(movie);
            movieReturn.Actors = new List<ActorInFilm>();
            movieReturn.Type = type.Name;

            foreach (var e in _context.MoviesToActor.Where(m=>m.MovieId == id))
            {
                Actor tmp = _context.Actors.FirstOrDefault(a => a.ActorId == e.Actor);
                ActorInFilm actor = new ActorInFilm
                {
                    NameSurname = tmp.Name + " " + tmp.Surname,
                    NameSurnameInFilm = e.ActorNameInMovie
                };
                movieReturn.Actors.Add(actor);
            }
            return new MovieResponse(movieReturn);
        }
    }
}


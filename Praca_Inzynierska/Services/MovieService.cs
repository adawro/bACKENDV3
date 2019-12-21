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

        public MovieService(IMapper mapper, IHttpContextAccessor httpContext, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _userName = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
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
            Dictionary<string, string> actorDicReturn = new Dictionary<string, string>();

            foreach (var e in movie.Actors)
            {
                Actor tmp = _context.Actors.FirstOrDefault(a => a.Id == e.Key);
                if(tmp == null)
                {
                    errors.Add(e.Key.ToString(), new[] { "Aktor o id = "+e.Key+" nie istnieje"});
                    continue;
                }
                string namer = tmp.Name + " " + tmp.Surname;
                MovieToActors actor = new MovieToActors { MovieId = movieSave.MovieId, Actor = e.Key, ActorNameInMovie = e.Value };
                actorListSave.Add(actor);
                ActorNames.Add(e.Value);
                actorDicReturn.Add(namer, e.Value);
            }

            if(errors!=null)
            {
                return new MovieResponse(errors);
            }
            movieSave.Actors = actorListSave;

            _context.MoviesToActor.AddRange(actorListSave);
            _context.Movies.Add(movieSave);
            _context.SaveChanges();

            movieReturn = _mapper.Map<Movie, MovieReturnDto>(movieSave);
            movieReturn.Actors = actorDicReturn;

            return new MovieResponse(movieReturn);
        }

        public MovieListResponse FindMovie(FindMovieDto movieTitle)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            var movie = _context.Movies.Where(m => m.Title.Contains(movieTitle.Title));

            if(movie==null)
            {
                errors.Add("Movie", new[] { "Nie istanieje taki film" });
                return new MovieListResponse(errors);
            }

            List<Movie> movieList = movie.ToList();
            List<MovieReturnForList> movieListReturn = _mapper.Map<List<Movie>, List<MovieReturnForList>>(movieList);

            MovieListReturnDto moviesReturn = new MovieListReturnDto
            {
                Movies = movieListReturn
            };
            return new MovieListResponse(moviesReturn);
        }

        public MovieReturnForActor FindMoviesForActor(int id)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            Actor actor = _context.Actors.FirstOrDefault(a => a.Id == id);
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
            movieReturn.Actors = new Dictionary<string, string>();
            movieReturn.Type = type.Name;

            foreach (var e in _context.MoviesToActor.Where(m=>m.MovieId == id))
            {
                Actor tmp = _context.Actors.FirstOrDefault(a => a.Id == e.Actor);
                movieReturn.Actors.Add(tmp.ActorName, e.ActorNameInMovie);
            }
            return new MovieResponse(movieReturn);
        }
    }
}


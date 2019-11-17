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

            Movie movieSave = new Movie
            {
                Type = type,
                Title = movie.Title,
                BoxOffice = movie.BoxOffice,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                TypeId = type.TypeId,
                DirectionBy = movie.DirectionBy,
                WrittenBy = movie.WrittenBy,
                Country = movie.Country
            };
            var actorListSave = new List<MovieToActors>();

            foreach (var e in movie.ActorId)
            {
                var tmp = _context.Actors.FirstOrDefault(a => a.Id == e);
                var actorName = tmp.Name + " " + tmp.Surname;
                var actor = new MovieToActors { MovieId = movieSave.MovieId, Actor = e, ActorName = actorName };
                actorListSave.Add(actor);
                ActorNames.Add(actorName);
            }

            try
            {
                movieSave.Actors = actorListSave;
                _context.MoviesToActor.AddRange(actorListSave);
                _context.Movies.Add(movieSave);
                movieReturn = _mapper.Map<Movie, MovieReturnDto>(movieSave);
                movieReturn.Actors = ActorNames;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add("Wystąpił nieoczekiwany błąd", new[] { ex.Message });
                return new MovieResponse(errors);
            }
            return new MovieResponse(movieReturn);
        }

        public MovieListResponse FindMoviesForActor(int id)
        {
            throw new NotImplementedException();
        }
    }
}

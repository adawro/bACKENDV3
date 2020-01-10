using AutoMapper;
using Microsoft.AspNetCore.Http;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Persistence;
using Praca_Inzynierska.Services.Communication;
using Praca_Inzynierska.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _userName;
        public CommentService(IMapper mapper, IHttpContextAccessor httpContext, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _userName = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
        }
        public CommentResponse AddComment(CommentSaveDto comment)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.UserName == _userName);

            if (user == null)
            {
                errors.Add("Konto", new[] { "Podane konto nie istnieje" });
                return new CommentResponse(errors);
            }
            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieId == comment.MovieId);
            if (movie == null)
            {
                errors.Add("Film", new[] { "Podany film nie istnieje" });
                return new CommentResponse(errors);
            }
            Comment userComment = _context.Comments.FirstOrDefault(u => u.UserName == _userName);
            if (userComment!=null)
            {
                errors.Add("Komentarz", new[] { "Dodałej juz ocene do tego filmu " });
                return new CommentResponse(errors);
            }
            try
            {
                Comment commentSave = _mapper.Map<CommentSaveDto, Comment>(comment);
                commentSave.UserName = user.UserName;
                _context.Comments.Add(commentSave);
                _context.SaveChanges();
                var movies = _context.Comments.Where(m => m.MovieId == comment.MovieId).ToArray();
                float ratio = 0;
                for (int i = 0; i < movies.Count(); i++)
                {
                    ratio += movies[i].Ratio;
                }
                ratio /= movies.Count();
                movie.Ratio = ratio;
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return new CommentResponse(commentSave);
            }
            catch (Exception ex)
            {

                errors.Add("Wystąpił nieoczekiwany błąd", new[] { ex.Message });
                return new CommentResponse(errors);
            }
        }

        public CommentListResponse GetCommentForMovie(int id)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                errors.Add("Film", new[] { "Podany film nie istnieje" });
                return new CommentListResponse(errors);
            }

            var comments = _context.Comments.Where(m => m.MovieId == id).ToList();

            if (comments == null)
            {
                errors.Add("Komentarze", new[] { "Podany film nie posiada komentarzy " });
                return new CommentListResponse(errors);
            }
            CommentListReturnDto commentListReturn = new CommentListReturnDto
            {
                CommentList = comments
            };
            return new CommentListResponse(commentListReturn);
            
        }
    }
}

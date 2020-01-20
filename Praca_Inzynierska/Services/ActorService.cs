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
using Praca_Inzynierska.Services;

namespace Praca_Inzynierska.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly string _userName;
        private readonly IImageActorService _imageService;

        public ActorService(IImageActorService imageService, IMapper mapper, IHttpContextAccessor httpContext, AppDbContext context, IMovieService movieService)
        {
            _mapper = mapper;
            _context = context;
            _movieService = movieService;
            _userName = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            _imageService = imageService;
        }

        public ActorDetailsResponse ActorDetails(int id)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            Actor actor = _context.Actors.Include(i=>i.Images)
                .FirstOrDefault(a => a.ActorId == id);

            if(actor == null)
            {
                errors.Add("Actor", new[] { "Nie istnieje dany actor" });
                return new ActorDetailsResponse(errors);
            }

            var movieList = _movieService.FindMoviesForActor(id);

            var actorDetail = _mapper.Map<Actor, ActorReturnDetails>(actor);
            actorDetail.Images = new List<string>();
            foreach (var e in actor.Images)
            {
                actorDetail.Images.Add(e.FileName);
            }
            actorDetail.Movies = movieList;
            return new ActorDetailsResponse(actorDetail);
        }

        public ActorResponse AddActor(ActorSaveDto actorSave)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            if(actorSave.Born > DateTime.Now)
            {
                errors.Add("Data", new[] { "Podana data jest nieprawidłowa" });
                return new ActorResponse(errors);
            }
            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.UserName == _userName || u.Email == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new ActorResponse(errors);
            }

            if(user.Rola != "admin" && user.Rola != "moderator")
            {
                errors.Add("User", new[] { "Nie masz dostepu do tej czesci serwisu" });
                return new ActorResponse(errors);
            }
            Actor actorModel = _mapper.Map<ActorSaveDto, Actor>(actorSave);
            actorModel.AccountCreate = user.UserName;
            actorModel.Age = DateTime.Now.Year - actorModel.Born.Year;

            List<ImageActor> uploadedImagesModels = new List<ImageActor>();
            if (actorSave.Images != null)
                try
                {
                    uploadedImagesModels =
                        _imageService.UploadImagesToServer(actorSave.Images, actorModel);
                }
                catch (Exception ex)
                {
                    errors.Add("Images", new[] { ex.Message });
                    return new ActorResponse(errors);
                }

            actorModel.Images = uploadedImagesModels;

            try
            {
                _context.ActorImages.AddRange(uploadedImagesModels);
                _context.Actors.Add(actorModel);
                _context.SaveChanges();
                ActorReturnDto actorReturnDto = _mapper.Map<Actor, ActorReturnDto>(actorModel);
                actorReturnDto.Images = new List<string>();
                foreach (var e in actorModel.Images)
                {
                    actorReturnDto.Images.Add(e.FileName);
                }
                return new ActorResponse(actorReturnDto);
            }
            catch (Exception ex)
            {
                errors.Add("Wystapil nieoczekiwany blad", new[] { ex.Message });

                return new ActorResponse(errors);
            }
            
        }

        public ActorResponse EditActor(int id, ActorEditDto actorEditDto)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            DateTime data = DateTime.Now;

            if (actorEditDto.Born > data)
            {
                errors.Add("Data", new[] { "Podana data jest nieprawidłowa" });
                return new ActorResponse(errors);
            }

            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.UserName == _userName);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new ActorResponse(errors);
            }

            if (user.Rola != "admin" && user.Rola != "moderator")
            {
                errors.Add("User", new[] { "Nie masz dostepu do tej czesci serwisu" });
                return new ActorResponse(errors);
            }

            Actor actor = _context.Actors.AsNoTracking().FirstOrDefault(act => act.ActorId == id);

            if (actor == null)
            {
                errors.Add("Aktor", new[] { "Szukany aktor nie istanieje w bazie" });
                return new ActorResponse(errors);
            }

            Actor actorEditModel = _mapper.Map<ActorEditDto, Actor>(actorEditDto);
            actorEditModel.ActorId = id;
            actorEditModel.AccountCreate = user.UserName;
            actorEditModel.Age = DateTime.Now.Year - actorEditModel.Born.Year;

            

            var listImageRemove = new List<ImageActor>();
            if (actorEditDto.RemoveImages != null)
                foreach (var fileName in actorEditDto.RemoveImages)
                {
                    var image = _context.ActorImages.FirstOrDefault(i => i.FileName == fileName);

                    if (image != null) _imageService.RemoveImages(actorEditDto.RemoveImages);

                }

            List<ImageActor> uploadedImagesModels = new List<ImageActor>();
            if (actorEditDto.Images != null)
                try
                {
                    uploadedImagesModels =
                        _imageService.UploadImagesToServer(actorEditDto.Images, actorEditModel);
                }
                catch (Exception ex)
                {
                    errors.Add("Images", new[] { ex.Message });
                    return new ActorResponse(errors);
                }
            try
            {
                _context.ActorImages.RemoveRange(listImageRemove);
                _context.ActorImages.AddRange(uploadedImagesModels);
                _context.Actors.Update(actorEditModel);
                _context.SaveChanges();
                ActorReturnDto actorReturnDto = _mapper.Map<Actor, ActorReturnDto>(actorEditModel);

                actorReturnDto.Images = new List<string>();
                foreach (var e in actorEditModel.Images)
                {
                    actorReturnDto.Images.Add(e.FileName);
                }

                return new ActorResponse(actorReturnDto);
            }
            catch (Exception ex)
            {
                errors.Add("Wystapil nieoczekiwany blad", new[] { ex.Message });

                return new ActorResponse(errors);
            }
        }

        public ActorListResponse FindActor(string findActor)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();


            List<ActorReturnDto> actors = new List<ActorReturnDto>();
            var actorss = _context.Actors;
            
            foreach (var e in actorss)
            {
                if (e.ActorName.Contains(findActor.ToUpper()) || e.ActorSurname.Contains(findActor.ToUpper()))
                {
                    actors.Add(_mapper.Map<Actor, ActorReturnDto>(e));
                }
            }

            if(actors==null)
            {
                errors.Add("Actor", new[] { "Nie ma takich aktorów" });
                return new ActorListResponse(errors);
            }

            ActorListReturnDto result = new ActorListReturnDto
            {
                ActorList = actors
            };
            return new ActorListResponse(result);
        }
    }
}

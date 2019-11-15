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
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _userEmail;

        public ActorService(IMapper mapper, IHttpContextAccessor httpContext, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _userEmail = httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
        }
        public ActorResponse AddActor(ActorSaveDto actorSave)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

            DateTime data = DateTime.Now;

            if(actorSave.Born > data)
            {
                errors.Add("Data", new[] { "Podana data jest nieprawidłowa" });
                return new ActorResponse(errors);
            }
            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.Email == _userEmail);
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

            try
            {
                _context.Actors.Add(actorModel);
                _context.SaveChanges();
                ActorReturnDto actorReturnDto = _mapper.Map<Actor, ActorReturnDto>(actorModel);
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

            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.Email == _userEmail);
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

            Actor actor = _context.Actors.AsNoTracking().FirstOrDefault(act => act.Id == id);

            if (actor == null)
            {
                errors.Add("Aktor", new[] { "Szukany aktor nie istanieje w bazie" });
                return new ActorResponse(errors);
            }

            Actor actorEditModel = _mapper.Map<ActorEditDto, Actor>(actorEditDto);
            actorEditModel.Id = id;
            actorEditModel.AccountCreate = user.UserName;
            actorEditModel.Age = DateTime.Now.Year - actorEditModel.Born.Year;

            try
            {
                _context.Actors.Update(actorEditModel);
                _context.SaveChanges();
                ActorReturnDto actorReturnDto = _mapper.Map<Actor, ActorReturnDto>(actorEditModel);
                return new ActorResponse(actorReturnDto);
            }
            catch (Exception ex)
            {
                errors.Add("Wystapil nieoczekiwany blad", new[] { ex.Message });

                return new ActorResponse(errors);
            }
        }

        public ActorListResponse FindActor(FindActorDto findActor)
        {
            Dictionary<string, string[]> errors = new Dictionary<string, string[]>();


            List<ActorReturnDto> actors = new List<ActorReturnDto>();
            UserAccount user = _context.UserAccounts.FirstOrDefault(u => u.Email == _userEmail);
            if (user == null)
            {
                errors.Add("User", new[] { "Podane konto nie istnieje" });
                return new ActorListResponse(errors);
            }
            
            foreach (var e in _context.Actors)
            {
                if (e.ActorName.Contains(findActor.ActorName.ToUpper()) || e.ActorSurname.Contains(findActor.ActorName.ToUpper()))
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

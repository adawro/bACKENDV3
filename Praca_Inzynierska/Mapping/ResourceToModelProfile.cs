using System.Linq;
using AutoMapper;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Models;
using Praca_Inzynierska.DTO.ReturnDto;

namespace Praca_Inzynierska.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegisterAccountDto, UserAccount>();
            CreateMap<ActorSaveDto, Actor>()
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Name.ToLower() + src.Surname.ToLower()));
            CreateMap<Actor, ActorReturnDto>();
            CreateMap<ActorListReturnDto, Actor>();
            CreateMap<Actor, ActorListReturnDto>();
            CreateMap<ActorEditDto, Actor>();
        }
    }
}

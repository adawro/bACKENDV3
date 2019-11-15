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
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Name.ToUpper() + " " + src.Surname.ToUpper()))
                .ForMember(dest => dest.ActorSurname, opt => opt.MapFrom(src => src.Surname.ToUpper() + " " + src.Name.ToUpper()));
            CreateMap<Actor, ActorReturnDto>();
            CreateMap<ActorListReturnDto, Actor>();
            CreateMap<Actor, ActorListReturnDto>();
            CreateMap<ActorEditDto, Actor>()
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Name.ToUpper() + " " + src.Surname.ToUpper()))
                .ForMember(dest => dest.ActorSurname, opt => opt.MapFrom(src => src.Surname.ToUpper() + " " + src.Name.ToUpper()));
        }
    }
}

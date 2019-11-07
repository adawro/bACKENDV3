using System.Linq;
using AutoMapper;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Models;

namespace Praca_Inzynierska.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegisterAccountDto, UserAccount>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}

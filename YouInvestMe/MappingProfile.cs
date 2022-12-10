using AutoMapper;
using YouInvestMe.Models;

namespace YouInvestMe
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Creates the map used in the AccountController Regsitration action
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}

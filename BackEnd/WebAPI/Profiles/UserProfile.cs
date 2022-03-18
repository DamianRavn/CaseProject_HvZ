using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.User;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>(); //.ForMember(cdto => cdto.Token, opt => opt.MapFrom(u=> JwtGenerator.GenerateUserToken(u.UserName)));
            CreateMap<UserCreateDTO, User>();
        }        
    }
}

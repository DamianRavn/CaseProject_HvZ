using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.User;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }        
    }
}

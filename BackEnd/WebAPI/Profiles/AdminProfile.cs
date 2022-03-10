using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Admin;

namespace WebAPI.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminReadDTO>()
                .ForMember(dto => dto.User, opt => opt
                .MapFrom(a => a.UserId))
                .ReverseMap();
            CreateMap<AdminCreateDTO, Admin>()
                .ForMember(cdto => cdto.UserId, opt => opt
                .MapFrom(a => a.User))
                .ForMember(cdto => cdto.User, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Game;

namespace WebAPI.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameReadDTO>()
                // admin in dto is admin_id
                .ForMember(dto => dto.Admin, opt => opt
                .MapFrom(a => a.AdminId))
                .ReverseMap();
            CreateMap<GameCreateDTO, Game>()
                //Ignore objects for DTO
                .ForMember(cdto => cdto.Admin, opt => opt.Ignore());
            CreateMap<GameUpdateDTO, Game>()
                // admin in dto is admin_id
                .ForMember(cdto => cdto.AdminId, opt => opt
                .MapFrom(a => a.Admin))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.Admin, opt => opt.Ignore());
        }
    }
}

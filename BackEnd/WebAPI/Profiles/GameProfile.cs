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
                .ForMember(dto => dto.admin, opt => opt
                .MapFrom(a => a.admin_id))
                .ReverseMap();
            CreateMap<GameCreateDTO, Game>()
                // admin in dto is admin_id
                .ForMember(cdto => cdto.admin_id, opt => opt
                .MapFrom(a => a.admin))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.admin, opt => opt.Ignore());
            CreateMap<GameUpdateDTO, Game>()
                // admin in dto is admin_id
                .ForMember(cdto => cdto.admin_id, opt => opt
                .MapFrom(a => a.admin))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.admin, opt => opt.Ignore());
        }
    }
}

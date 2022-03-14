using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Player;

namespace WebAPI.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerReadDTO>()
                // User in dto is User_id
                .ForMember(dto => dto.User, opt => opt
                .MapFrom(a => a.UserId))
                .ForMember(dto => dto.Game, opt => opt
                .MapFrom(a => a.GameId))
                .ReverseMap();
            CreateMap<PlayerCreateDTO, Player>()
                // User in dto is User_id
                .ForMember(cdto => cdto.UserId, opt => opt
                .MapFrom(a => a.User))
                .ForMember(cdto => cdto.GameId, opt => opt
                .MapFrom(a => a.Game))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.User, opt => opt.Ignore())
                .ForMember(cdto => cdto.Game, opt => opt.Ignore());
            CreateMap<PlayerUpdateDTO, Player>()
                // User in dto is User_id
                .ForMember(cdto => cdto.UserId, opt => opt
                .MapFrom(a => a.User))
                .ForMember(cdto => cdto.GameId, opt => opt
                .MapFrom(a => a.Game))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.User, opt => opt.Ignore())
                .ForMember(cdto => cdto.Game, opt => opt.Ignore());
            CreateMap<Player, PlayerReadDTONonAdmin>()
                // User in dto is User_id
                .ForMember(dto => dto.User, opt => opt
                .MapFrom(a => a.UserId))
                .ForMember(dto => dto.Game, opt => opt
                .MapFrom(a => a.GameId))
                .ReverseMap();
        }
    }
}

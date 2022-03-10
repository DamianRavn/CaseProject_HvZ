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
                // user in dto is user_id
                .ForMember(dto => dto.user, opt => opt
                .MapFrom(a => a.user_id))
                .ForMember(dto => dto.game, opt => opt
                .MapFrom(a => a.game_id))
                .ReverseMap();
            CreateMap<PlayerCreateDTO, Player>()
                // user in dto is user_id
                .ForMember(cdto => cdto.user_id, opt => opt
                .MapFrom(a => a.user))
                .ForMember(cdto => cdto.game_id, opt => opt
                .MapFrom(a => a.game))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.user, opt => opt.Ignore())
                .ForMember(cdto => cdto.game, opt => opt.Ignore());
            CreateMap<PlayerUpdateDTO, Player>()
                // user in dto is user_id
                .ForMember(cdto => cdto.user_id, opt => opt
                .MapFrom(a => a.user))
                .ForMember(cdto => cdto.game_id, opt => opt
                .MapFrom(a => a.game))
                //Ignore objects for DTO
                .ForMember(cdto => cdto.user, opt => opt.Ignore())
                .ForMember(cdto => cdto.game, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Game;

namespace WebAPI.Profiles
{
    /// <summary>
    /// Defines the maps between Game and its DTOs.
    /// </summary>
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameReadDTO>()
                // Turning related players into an array of int ids.
                .ForMember(gdto => gdto.Players, opt => opt
                .MapFrom(g => g.Players.Select(c => c.Id).ToArray()))
                // Include id of admin.
                .ForMember(dto => dto.Admin, opt => opt
                .MapFrom(a => a.AdminId))
                .ReverseMap();
            CreateMap<GameCreateDTO, Game>()
                // Ignore objects for DTO.
                .ForMember(cdto => cdto.Admin, opt => opt.Ignore());
            CreateMap<GameUpdateDTO, Game>()
                // Include id of admin.
                .ForMember(cdto => cdto.AdminId, opt => opt
                .MapFrom(a => a.Admin))
                // Ignore objects for DTO.
                .ForMember(cdto => cdto.Admin, opt => opt.Ignore());
        }
    }
}

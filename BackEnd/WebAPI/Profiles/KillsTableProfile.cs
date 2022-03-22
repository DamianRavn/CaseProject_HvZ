using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.KillsTable;

namespace WebAPI.Profiles
{
    /// <summary>
    /// Defines the maps between Game and its DTOs.
    /// </summary>
    public class KillsTableProfile : Profile
    {
        public KillsTableProfile()
        {
            CreateMap<KillsTable, KillsReadDTO>()
                // Turning related users into an array of int ids.
                .ForMember(gdto => gdto.Users, opt => opt
                .MapFrom(g => g.Users.Select(c => c.Id).ToArray()))
                // Include id of user.
                .ForMember(dto => dto.User, opt => opt
                .MapFrom(a => a.UserId))
                .ReverseMap();
            CreateMap<KillsCreateDTO, KillsTable>()
                //Ignore objects for DTO
                .ForMember(cdto => cdto.User, opt => opt.Ignore())
                .ForMember(cdto => cdto.Users, opt => opt.Ignore());
            CreateMap<KillsUpdateDTO, KillsTable>();
        }
    }
}

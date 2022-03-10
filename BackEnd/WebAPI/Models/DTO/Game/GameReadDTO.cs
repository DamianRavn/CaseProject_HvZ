using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.Game
{
    public class GameReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GameState { get; set; }
        public int Admin { get; set; }
    }
}

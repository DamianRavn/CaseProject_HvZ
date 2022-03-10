using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.Game
{
    public class GameCreateDTO
    {
        public string name { get; set; }
        public string game_state { get; set; }
        public int admin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Game
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public State game_state { get; set; }
        
        [Required]
        public int admin_id { get; set; }
        public Admin admin { get; set; }

        public enum State { registation, in_progress, complete }
    }
}

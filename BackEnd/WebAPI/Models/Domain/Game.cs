using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public State GameState { get; set; }
        
        [Required]
        public int AdminId { get; set; }
        public Admin Admin { get; set; }

        public enum State { Registation, InProgress, Complete }
    }
}

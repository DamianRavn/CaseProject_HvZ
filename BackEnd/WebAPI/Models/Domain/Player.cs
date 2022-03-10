using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Domain
{
    public class Player
    {
        public int id { get; set; }
        [Required]
        public bool is_human { get; set; }
        [Required]
        public bool is_patient_zero { get; set; }
        [Required, StringLength(5)]
        public string biteCode { get; set; }
        [Required]
        public int user_id { get; set; }
        public User user { get; set; }
        [Required]
        public int game_id { get; set; }
        public Game game { get; set; }
    }
}

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
        [StringLength(10)]
        public string biteCode { get; set; }
        public int user_id { get; set; }
        public User user { get; set; }
        public int game_id { get; set; }
        public Game game { get; set; }
    }
}

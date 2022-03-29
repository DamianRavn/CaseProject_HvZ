using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Domain
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public bool IsHuman { get; set; }
        public bool IsPatientZero { get; set; }
        [StringLength(5)]
        public string BiteCode { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? GameId { get; set; }
        public Game Game { get; set; }
    }
}

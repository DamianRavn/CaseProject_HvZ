﻿using System;
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
        [Required]
        public bool IsPatientZero { get; set; }
        [Required, StringLength(5)]
        public string BiteCode { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}

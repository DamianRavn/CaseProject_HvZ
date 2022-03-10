using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.Player
{
    public class PlayerUpdateDTO
    {
        public int Id { get; set; }
        public bool IsHuman { get; set; }
        public bool IsPatientZero { get; set; }
        public string BiteCode { get; set; }
        public int User { get; set; }
        public int Game { get; set; }
    }
}

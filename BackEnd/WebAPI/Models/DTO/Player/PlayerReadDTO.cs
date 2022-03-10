using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.Player
{
    public class PlayerReadDTO
    {
        public int id { get; set; }
        public bool is_human { get; set; }
        public bool is_patient_zero { get; set; }
        public string biteCode { get; set; }
        public int user { get; set; }
        public int game { get; set; }
    }
}

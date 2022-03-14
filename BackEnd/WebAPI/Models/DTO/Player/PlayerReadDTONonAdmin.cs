using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.Player
{
    public class PlayerReadDTONonAdmin
    {
        public int Id { get; set; }
        public bool IsHuman { get; set; }
        public int User { get; set; }
        public int Game { get; set; }
    }
}

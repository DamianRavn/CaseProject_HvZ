using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.KillsTable
{
    public class KillsCreateDTO
    {
        public int User { get; set; }
        public List<int> Users { get; set; }
    }
}

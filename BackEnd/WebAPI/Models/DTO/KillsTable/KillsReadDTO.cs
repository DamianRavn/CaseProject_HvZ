using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DTO.KillsTable
{
    public class KillsReadDTO
    {
        public int Id { get; set; }
        public int User { get; set; }
        public List<int> Users { get; set; }
    }
}

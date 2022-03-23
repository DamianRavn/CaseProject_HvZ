using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Domain
{
    public class KillsTable
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

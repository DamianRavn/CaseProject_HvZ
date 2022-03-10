using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Domain
{
    public class User
    {
        public int id { get; set; }
        [Required, MaxLength(20)]
        public string first_name { get; set; }
        [Required, MaxLength(20)]
        public string last_name { get; set; }
    }
}

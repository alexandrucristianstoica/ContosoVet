using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Models
{
    public class Person : BaseModel
    {
        [Required]
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


    }
}

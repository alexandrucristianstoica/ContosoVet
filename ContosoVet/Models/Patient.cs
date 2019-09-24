using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Models
{
    public class Patient : BaseModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(0,30)]
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public Client Owner { get; set; }

    }
}

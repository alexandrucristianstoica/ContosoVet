using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Models
{
    public class Appointment 
    {
        public int Id { get; set; }

        public Doctor Doctor { get; set; }

        public Technician Technician { get; set; }

        public Patient Patient { get; set; }

        public DateTime DateTime { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Models
{
    public class Client : Person
    {
        public List<Patient> Patients { get; set; }
    }
}

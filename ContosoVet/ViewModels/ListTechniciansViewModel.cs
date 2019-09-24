using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.ViewModels
{
    public class ListTechniciansViewModel
    {
        public IEnumerable<Technician> Technicians { get; set; }
    }
}

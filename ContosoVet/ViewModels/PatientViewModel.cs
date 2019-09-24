using ContosoVet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }
        public List<SelectListItem> Clients { get; set; }
    }
}

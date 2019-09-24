using ContosoVet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.ViewModels
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }

        public List<SelectListItem> Patients { get; set; }

        public List<SelectListItem> Doctors { get; set; }

        public List<SelectListItem> Technicians { get; set; }
    }
}

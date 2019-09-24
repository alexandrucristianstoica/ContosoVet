using ContosoVet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.ViewModels
{
    public class ListAppointmentsViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}

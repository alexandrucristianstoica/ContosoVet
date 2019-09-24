using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IAppointmentRepository 
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        bool CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment updatedappointment, int id);
        bool DeleteAppointment(int id);
    }
}

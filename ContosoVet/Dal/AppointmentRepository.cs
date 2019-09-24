using ContosoVet.Interfaces;
using ContosoVet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private ContosoVetDbContext _ctx;

        public AppointmentRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            try
            {
                _ctx.Appointments.Add(appointment);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteAppointment(int id)
        {
            try
            {
                var toDelete = _ctx.Appointments.FirstOrDefault(c => c.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Appointments.Remove(toDelete);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _ctx.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Technician)
                .OrderByDescending(d=>d.DateTime);
        }

        public Appointment GetAppointmentById(int id)

        {
            var appointment = _ctx.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Technician)
                .FirstOrDefault(a => a.Id == id);
            return appointment;
        }

        public bool UpdateAppointment(Appointment updatedappointment, int id)
        {
            try
            {
                updatedappointment.Id = id;
                _ctx.Appointments.Update(updatedappointment);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}

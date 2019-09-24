using ContosoVet.Interfaces;
using ContosoVet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepository _apprepo;
        private IPatientRepository _patientrepo;
        private IDoctorRepository _doctorrepo;
        private ITechnicianRepository _techrepo;

        public AppointmentController(IAppointmentRepository apprepo, IPatientRepository patientrepo, IDoctorRepository doctorrepo, ITechnicianRepository techrepo)
        {
            _apprepo = apprepo;
            _patientrepo = patientrepo;
            _doctorrepo = doctorrepo;
            _techrepo = techrepo;
        }

        

        public IActionResult ListAppointments()
        {
            var appVm = new ListAppointmentsViewModel();
            appVm.Appointments = _apprepo.GetAllAppointments();
            return View(appVm);

        }

        public IActionResult Appointment(int id)
        {
            var appVm = new AppointmentViewModel();
            appVm.Patients = _patientrepo.GetAllPatients().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
            appVm.Doctors = _doctorrepo.GetAllDoctors().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
            appVm.Technicians = _techrepo.GetAllTechnicians().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();


            if (id == 0)
            {
                return View(appVm);
            }
            else
            {
                appVm.Appointment = _apprepo.GetAppointmentById(id);
                return View(appVm);
            }

        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentViewModel viewmodel)
        {

            viewmodel.Appointment.Patient = _patientrepo.GetPatientById(viewmodel.Appointment.Patient.Id);
            viewmodel.Appointment.Doctor = _doctorrepo.GetDoctorById(viewmodel.Appointment.Doctor.Id);
            viewmodel.Appointment.Technician = _techrepo.GetTechnicianById(viewmodel.Appointment.Technician.Id);
            _apprepo.CreateAppointment(viewmodel.Appointment);

            return RedirectToAction("ListAppointments");

        }

        [HttpPost]
        public IActionResult Update(AppointmentViewModel viewmodel)
        {

            viewmodel.Appointment.Patient = _patientrepo.GetPatientById(viewmodel.Appointment.Patient.Id);
            viewmodel.Appointment.Doctor = _doctorrepo.GetDoctorById(viewmodel.Appointment.Doctor.Id);
            viewmodel.Appointment.Technician = _techrepo.GetTechnicianById(viewmodel.Appointment.Technician.Id);
            _apprepo.UpdateAppointment(viewmodel.Appointment, viewmodel.Appointment.Id);

            return RedirectToAction("ListAppointments");
        }

        public IActionResult Delete(int id)
        {
            var result = _apprepo.DeleteAppointment(id);
            return RedirectToAction("ListAppointments");
        }


    }
}

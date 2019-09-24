using ContosoVet.Interfaces;
using ContosoVet.Models;
using ContosoVet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorRepository _docrepo;

        public DoctorController(IDoctorRepository docrepo)
        {
            _docrepo = docrepo;     
        }

        public IActionResult ListDoctors()
        {
            var doctorsVm = new ListDoctorsViewModel();
            doctorsVm.Doctors = _docrepo.GetAllDoctors();
            return View(doctorsVm);
        }

        public IActionResult Doctor(int id)
        {
            var doctorVm = new DoctorViewModel();

            if (id == 0)
            {
                doctorVm = new DoctorViewModel();
                return View(doctorVm);
            }
            else
            {
                doctorVm.Doctor = _docrepo.GetDoctorById(id);
                return View(doctorVm);
            }

        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            _docrepo.CreateDoctor(doctor);
            return RedirectToAction("ListDoctors");
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            var result = _docrepo.UpdateDoctor(doctor, doctor.Id);
            return RedirectToAction("ListDoctors");
        }

        public IActionResult Delete(int id)
        {
            var result = _docrepo.DeleteDoctor(id);
            return RedirectToAction("ListDoctors");
        }

    }
}

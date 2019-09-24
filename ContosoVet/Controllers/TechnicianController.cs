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
    public class TechnicianController : Controller
    {
        private ITechnicianRepository _techrepo;

        public TechnicianController(ITechnicianRepository techrepo)
        {
            _techrepo = techrepo;
        }

        public IActionResult ListTechnicians()
        {
            var techsVm = new ListTechniciansViewModel();
           techsVm.Technicians = _techrepo.GetAllTechnicians();
            return View(techsVm);
        }

        public IActionResult Technician(int id)
        {
            var techVm = new TechnicianViewModel();
            if (id == 0)
            {
                techVm = new TechnicianViewModel();
                return View(techVm);
            }
            else
            {
                techVm.Technician = _techrepo.GetTechnicianById(id);
                return View(techVm);
            }
        }

         [HttpPost]
         public IActionResult CreateTechnician(Technician technician)
        {
            var result = _techrepo.CreateTechnician(technician);
            return RedirectToAction("ListTechnicians");
        }

        [HttpPost]
        public IActionResult Update(Technician technician)
        {
            var result = _techrepo.UpdateTechnician(technician, technician.Id);
            return RedirectToAction("ListTechnicians");
        }

        public IActionResult Delete(int id)
        {
            var result = _techrepo.DeleteTechnician(id);
            return RedirectToAction("ListTechnicians");
        }

      
    }
}

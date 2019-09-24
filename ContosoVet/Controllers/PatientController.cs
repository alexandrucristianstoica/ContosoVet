using ContosoVet.Interfaces;
using ContosoVet.Models;
using ContosoVet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ContosoVet.Controllers
{
    public class PatientController : Controller
    {
        private IPatientRepository _patientrepo;
        private IClientRepository _clientrepo;

        public PatientController(IPatientRepository patientrepo, IClientRepository clientrepo)
        {
            _patientrepo = patientrepo;
            _clientrepo = clientrepo;
        }

        public IActionResult ListPatients()
        {
            var patientVm = new ListPatientsViewModel();
            patientVm.Patients = _patientrepo.GetAllPatients();
            return View(patientVm);

        }

        public IActionResult Patient(int id)
        {
            var patientVm = new PatientViewModel();
            patientVm.Clients = _clientrepo.GetAllClients().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();


            if (id == 0)
            {
                return View(patientVm);
            }
            else
            {
                patientVm.Patient = _patientrepo.GetPatientById(id);
                return View(patientVm);
            }

        }

        [HttpPost]
        public IActionResult CreatePatient(PatientViewModel viewmodel)
        {

            viewmodel.Patient.Owner = _clientrepo.GetClientById(viewmodel.Patient.Owner.Id);
            _patientrepo.CreatePatient(viewmodel.Patient);

           return RedirectToAction("ListPatients");

        }

        [HttpPost]
        public IActionResult Update(PatientViewModel viewmodel)
        {

            viewmodel.Patient.Owner = _clientrepo.GetClientById(viewmodel.Patient.Owner.Id);
            _patientrepo.UpdatePatient(viewmodel.Patient,viewmodel.Patient.Id);

            return RedirectToAction("ListPatients");
        }
        
        public IActionResult Delete(int id)
        {
            var result = _patientrepo.DeletePatient(id);
            return RedirectToAction("ListPatients");
        }


    }
}

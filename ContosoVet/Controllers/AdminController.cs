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
    public class AdminController : Controller
    {
        private IAdminRepository _adminRepo;

        public AdminController(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public IActionResult ListAdmins()
        {
            var adminsVm = new ListAdminsViewModels();
            adminsVm.Admins = _adminRepo.GetAllAdmins();
            return View(adminsVm);
        }

        public IActionResult Admin(int id)
        {
            var adminVm = new AdminViewModel();

            if (id == 0)
            {
                adminVm = new AdminViewModel();
                return View(adminVm);
            }
            else
            {
                adminVm.Admin = _adminRepo.GetAdminById(id);
                return View(adminVm);
            }
        }

        [HttpPost]
        public IActionResult CreateAdmin(Admin admin)
        {
            _adminRepo.CreateAdmin(admin);
            return RedirectToAction("ListAdmins");
        }

        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            var result = _adminRepo.UpdateAdmin(admin, admin.Id);
            return RedirectToAction("ListAdmins");
        }

        public IActionResult Delete(int id)
        {
            var result = _adminRepo.DeleteAdmin(id);
            return RedirectToAction("ListAdmins");
        }
    }
}

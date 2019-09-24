using ContosoVet.Interfaces;
using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Services
{
    public class UserService : IUserService
    {
        private IAdminRepository _adminRepo;

        public UserService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public bool CreateAdmin(Admin admin)
        {
            return _adminRepo.CreateAdmin(admin);
        }

        public bool ValidateCredentials(string username, string password, out Admin admin)
        {
            var searchAdmin = _adminRepo.GetAdminByUsername(username);
            if (searchAdmin != null && searchAdmin.Password == password)
            {
                admin = searchAdmin;
                return true;
            }
            else
            {
                admin = null;
                return false;
            }
        }
    }
}

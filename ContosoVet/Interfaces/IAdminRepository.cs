using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        Admin GetAdminByUsername(string username);
        bool CreateAdmin(Admin admin);
        bool UpdateAdmin(Admin updatedAdmin, int id);
        bool DeleteAdmin(int id);

    }
}

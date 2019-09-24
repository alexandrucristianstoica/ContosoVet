using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password, out Admin admin);
        bool CreateAdmin(Admin admin);
    }
}

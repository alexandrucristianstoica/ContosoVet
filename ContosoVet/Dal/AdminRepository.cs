using ContosoVet.Interfaces;
using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class AdminRepository : IAdminRepository
    {

        private ContosoVetDbContext _ctx;

        public AdminRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreateAdmin(Admin admin)
        {
            try
            {
                _ctx.Admins.Add(admin);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                var toDelete = _ctx.Admins.FirstOrDefault(a => a.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Admins.Remove(toDelete);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public Admin GetAdminById(int id)
        {
            return _ctx.Admins.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _ctx.Admins.OrderBy(n=>n.Name);
        }

        public bool UpdateAdmin(Admin updatedAdmin, int id)
        {
            try
            {
                updatedAdmin.Id = id;
                _ctx.Admins.Update(updatedAdmin);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            return _ctx.Admins.FirstOrDefault(a => a.Username == username);
        }
    }
}

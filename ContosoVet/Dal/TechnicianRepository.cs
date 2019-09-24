using ContosoVet.Interfaces;
using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class TechnicianRepository : ITechnicianRepository
    {

        private ContosoVetDbContext _ctx;

        public TechnicianRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreateTechnician(Technician technician)
        {
            try
            {
                _ctx.Technicians.Add(technician);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteTechnician(int id)
        {
            try
            {
                var toDelete = _ctx.Technicians.FirstOrDefault(c => c.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Technicians.Remove(toDelete);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public IEnumerable<Technician> GetAllTechnicians()
        {
            return _ctx.Technicians;
        }

        public Technician GetTechnicianById(int id)
        {
            return _ctx.Technicians.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateTechnician(Technician updatedTechnician, int id)
        {
            try
            {
                updatedTechnician.Id = id;
                _ctx.Technicians.Update(updatedTechnician);
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

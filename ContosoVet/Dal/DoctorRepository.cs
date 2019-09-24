using ContosoVet.Interfaces;
using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class DoctorRepository : IDoctorRepository
    {
        private ContosoVetDbContext _ctx;

        public DoctorRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }


        public bool CreateDoctor(Doctor doctor)
        {
            try
            {
                _ctx.Doctors.Add(doctor);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteDoctor(int id)
        {
            try
            {
                var toDelete = _ctx.Doctors.FirstOrDefault(d => d.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Doctors.Remove(toDelete);
                _ctx.SaveChanges();
                return true;

            }
            catch (Exception e)
            {

                return false;
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _ctx.Doctors;
        }

        public Doctor GetDoctorById(int id)
        {
            return _ctx.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public bool UpdateDoctor(Doctor updatedDoctor, int id)
        {
            try
            {
                updatedDoctor.Id = id;
                _ctx.Doctors.Update(updatedDoctor);
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

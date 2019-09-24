using ContosoVet.Interfaces;
using ContosoVet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class PatientRepository : IPatientRepository
    {
        private ContosoVetDbContext _ctx;

        public PatientRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreatePatient(Patient patient)
        {
            try
            {
                _ctx.Patients.Add(patient);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeletePatient(int id)
        {
            try
            {
                var toDelete = _ctx.Patients.FirstOrDefault(p => p.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Patients.Remove(toDelete);
                _ctx.SaveChanges();
                return true;

            }
            catch (Exception e)
            {

                return false;
            }
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _ctx.Patients.OrderBy(p => p.Name).Include(o=>o.Owner);
        }

        public Patient GetPatientById(int id)
        {
            var patient = _ctx.Patients
                .Include(c=>c.Owner)
                .FirstOrDefault(p => p.Id == id);
            return patient;
        }

        public bool UpdatePatient(Patient updatedPatient, int id)
        {
            try
            {
                updatedPatient.Id = id;
                _ctx.Patients.Update(updatedPatient);
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

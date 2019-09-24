using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        bool CreatePatient(Patient patient);
        bool UpdatePatient(Patient updatedPatient, int id);
        bool DeletePatient(int id);

    }
}

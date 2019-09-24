using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int id);
        bool CreateDoctor(Doctor doctor);
        bool UpdateDoctor(Doctor updatedDoctor, int id);
        bool DeleteDoctor(int id);

    }
}

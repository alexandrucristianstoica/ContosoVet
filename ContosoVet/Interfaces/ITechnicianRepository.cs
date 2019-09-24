using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface ITechnicianRepository
    {
        IEnumerable<Technician> GetAllTechnicians();
        Technician GetTechnicianById(int id);
        bool CreateTechnician(Technician technician);
        bool UpdateTechnician(Technician updatedTechnician, int id);
        bool DeleteTechnician(int id);

    }
}

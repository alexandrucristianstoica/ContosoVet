using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        bool CreateClient(Client client);
        bool UpdateClient(Client updatedClient, int id);
        bool DeleteClient(int id);
    }
}

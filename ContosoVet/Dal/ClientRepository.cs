using ContosoVet.Interfaces;
using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class ClientRepository : IClientRepository
    {
        private ContosoVetDbContext _ctx;

        public ClientRepository(ContosoVetDbContext ctx)
        {
            _ctx = ctx;
        }


        public bool CreateClient(Client client)
        {
            try
            {
                _ctx.Clients.Add(client);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool DeleteClient(int id)
        {
            try
            {
                var toDelete = _ctx.Clients.FirstOrDefault(c => c.Id == id);
                if (toDelete == null)
                    return false;
                _ctx.Clients.Remove(toDelete);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _ctx.Clients.OrderBy(c=>c.Name);
        }

        public Client GetClientById(int id)
        {
            return _ctx.Clients.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateClient(Client updatedClient, int id)
        {
            try
            {
                updatedClient.Id = id;
                _ctx.Clients.Update(updatedClient);
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

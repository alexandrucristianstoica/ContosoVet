using ContosoVet.Interfaces;
using ContosoVet.Models;
using ContosoVet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Controllers
{
    
    public class ClientController : Controller
    {
        private IClientRepository _clientRepo;

        public ClientController(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public IActionResult ListClients()
        {
            var clientsVm = new ListClientsViewModel();
            clientsVm.Clients = _clientRepo.GetAllClients();
            return View(clientsVm);
        }

        public IActionResult Client(int id)
        {
            var clientVm = new ClientViewModel();

            if (id == 0)
            {
                clientVm = new ClientViewModel();
                return View(clientVm);
            }
            else
            {
                clientVm.Client = _clientRepo.GetClientById(id);
                return View(clientVm);
            }
        }

        [HttpPost]
        public IActionResult CreateClient(Client client)
        {
            _clientRepo.CreateClient(client);
            return RedirectToAction("ListClients");
        }

        [HttpPost]
        public IActionResult Update(Client client)
        {
            var result = _clientRepo.UpdateClient(client, client.Id);
            return RedirectToAction("ListClients");
        }

        public IActionResult Delete(int id)
        {
            var result = _clientRepo.DeleteClient(id);
            return RedirectToAction("ListClients");
        }

    }
}

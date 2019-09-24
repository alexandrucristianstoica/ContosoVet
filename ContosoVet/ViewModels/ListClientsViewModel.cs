using ContosoVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.ViewModels
{
    public class ListClientsViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}

using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class ClienteService : ICliente
    {
        ClientComponent bs = new ClientComponent();

        public ClienteService()
        {

        }

        public Client Add(Client cliente)
        {            
            var model = bs.Add(cliente);
            return model;
        }

        public void Delete(int id)
        {
            bs.Delete(id);
        }

        public Client Find(int id)
        {
            return bs.Find(id);
        }

        public List<Client> ToList()
        {
            var especies = bs.ToList();
            return especies;
        }

        public Client Update(int id, Client cliente)
        {
            bs.Update(cliente);
            return cliente;
        }
    }
}

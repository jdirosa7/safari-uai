using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class ClientComponent
    {

        ClientDAC dac = new ClientDAC();

        public Client Add(Client client)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("NumeroMatricula", client.Email);

            List<Client> clients = dac.ReadyByFilters(filters);

            if (clients.Count > 0)
            {
                //Existe un doctor ya con esos datos 
                return client;
            }


            Client result = default(Client);

            result = dac.Create(client);
            return result;
        }

        public void Update(Client client)
        {
            dac.Update(client);
        }

        public void Delete(int id)
        {            
            dac.Delete(id);
        }

        public Client Find(int id)
        {
            Client result = default(Client);

            result = dac.ReadBy(id);
            return result;
        }

        public List<Client> List()
        {
            List<Client> result = default(List<Client>);

            result = dac.Read();
            return result;
        }
    }
}

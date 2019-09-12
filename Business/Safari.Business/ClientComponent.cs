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
        public Client Add(Client client)
        {
            Client result = default(Client);
            var dac = new ClientDAC();

            result = dac.Create(client);
            return result;
        }

        public void Update(Client client)
        {
            var dac = new ClientDAC();
            dac.Update(client);
        }

        public void Delete(int id)
        {
            var dac = new ClientDAC();
            dac.Delete(id);
        }

        public List<Client> List()
        {
            List<Client> result = default(List<Client>);

            var dac = new ClientDAC();
            result = dac.Read();
            return result;
        }
    }
}

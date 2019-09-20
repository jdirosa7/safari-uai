using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface ICliente
    {
        List<Client> ToList();
        Client Find(int id);
        Client Add(Client especie);
        Client Update(int id, Client especie);
        void Delete(int id);
    }
}

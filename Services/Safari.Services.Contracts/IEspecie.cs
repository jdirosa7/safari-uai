using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IEspecie
    {
        List<Especie> Listar();
        Especie Agregar(Especie especie);
    }
}

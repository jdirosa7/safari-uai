using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities;
using Safari.Services.Contracts;
using Safari.Business;

namespace Safari.Services
{
    public class EspecieService : IEspecie
    {
        public Species Agregar(Species especie)
        {
            var bs = new SpecieComponent();
            var model = bs.Add(especie);
            return model;
        }

        public List<Species> Listar()
        {            
            var bs = new SpecieComponent();
            var especies = bs.List();
            return especies;
        }
    }
}

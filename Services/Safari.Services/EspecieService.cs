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
        public Especie Agregar(Especie especie)
        {
            var bs = new EspecieComponent();
            var model = bs.Add(especie);
            return model;
        }

        public List<Especie> Listar()
        {            
            var bs = new EspecieComponent();
            var especies = bs.List();
            return especies;
        }
    }
}

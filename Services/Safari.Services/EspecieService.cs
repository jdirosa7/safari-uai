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

        SpecieComponent bs = new SpecieComponent();

        public EspecieService()
        {

        }

        public Species Add(Species especie)
        {
            var model = bs.Add(especie);
            return model;
        }

        public void Delete(int id)
        {
            bs.Delete(id);
        }

        public Species Find(int id)
        {
            return bs.Find(id);
        }

        public List<Species> ToList()
        {      
            var especies = bs.List();
            return especies;
        }

        public Species Update(int id, Species especie)
        {
            bs.Update(especie);
            return especie;
        }
    }
}

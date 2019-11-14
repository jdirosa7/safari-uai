using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class SpecieComponent
    {
        SpecieDAC dac = new SpecieDAC();


        public Species Add(Species especie)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("Nombre", especie.Nombre);

            List<Species> species = dac.ReadyByFilters(filters);

            if(species.Count > 0)
            {
                return especie;
            }


            Species result = default(Species);

            result = dac.Create(especie);
            return result;
        }

        public void Update(Species especie)
        {
            dac.Update(especie);
        }

        public void Delete(int id)
        {
            dac.Delete(id);
        }

        public Species Find(int id)
        {
            Species result = default(Species);

            result = dac.ReadBy(id);
            return result;
        }

        public List<Species> List()
        {
            List<Species> result = default(List<Species>);

            result = dac.Read();
            return result;
        }
    }
}

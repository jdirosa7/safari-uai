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
        public Species Add(Species especie)
        {
            Species result = default(Species);
            var especieDAC = new SpecieDAC();

            result = especieDAC.Create(especie);
            return result;
        }

        public void Update(Species especie)
        {
            var especieDAC = new SpecieDAC();
            especieDAC.Update(especie);
        }

        public void Delete(int id)
        {
            var especieDAC = new SpecieDAC();
            especieDAC.Delete(id);
        }

        public List<Species> List()
        {
            List<Species> result = default(List<Species>);

            var especieDAC = new SpecieDAC();
            result = especieDAC.Read();
            return result;
        }
    }
}

using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class PatientComponent
    {

        PatientDAC dac = new PatientDAC();

        public Patient Add(Patient patient)
        {
            Patient result = default(Patient);            

            result = dac.Create(patient);
            return result;
        }

        public void Update(Patient patient)
        {
            dac.Update(patient);
        }

        public void Delete(int id)
        {
            dac.Delete(id);
        }

        public Patient Find(int id)
        {
            Patient result = default(Patient);

            result = dac.ReadBy(id);
            return result;
        }

        public List<Patient> List()
        {
            List<Patient> result = default(List<Patient>);

            result = dac.Read();
            return result;
        }
    }
}

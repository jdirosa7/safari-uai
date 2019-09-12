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
        public Patient Add(Patient patient)
        {
            Patient result = default(Patient);
            var patientDAC = new PatientDAC();

            result = patientDAC.Create(patient);
            return result;
        }

        public void Update(Patient patient)
        {
            var patientDAC = new PatientDAC();
            patientDAC.Update(patient);
        }

        public void Delete(int id)
        {
            var patientDAC = new PatientDAC();
            patientDAC.Delete(id);
        }

        public List<Patient> List()
        {
            List<Patient> result = default(List<Patient>);

            var patientDAC = new PatientDAC();
            result = patientDAC.Read();
            return result;
        }
    }
}

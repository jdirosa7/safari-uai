using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class PatientDAC : DataAccessComponent, IRepository<Patient>
    {
        public Patient Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> Read()
        {
            throw new NotImplementedException();
        }

        public Patient ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}

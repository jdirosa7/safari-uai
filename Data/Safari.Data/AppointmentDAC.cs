using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class AppointmentDAC : DataAccessComponent, IRepository<Appointment>
    {
        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> Read()
        {
            throw new NotImplementedException();
        }

        public Appointment ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}

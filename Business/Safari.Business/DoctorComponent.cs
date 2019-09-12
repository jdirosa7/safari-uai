using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class DoctorComponent
    {
        public Doctor Add(Doctor doctor)
        {
            Doctor result = default(Doctor);
            var dac = new DoctorDAC();

            result = dac.Create(doctor);
            return result;
        }

        public void Update(Doctor doctor)
        {
            var dac = new DoctorDAC();
            dac.Update(doctor);
        }

        public void Delete(int id)
        {
            var dac = new DoctorDAC();
            dac.Delete(id);
        }

        public List<Doctor> List()
        {
            List<Doctor> result = default(List<Doctor>);

            var dac = new DoctorDAC();
            result = dac.Read();
            return result;
        }
    }
}

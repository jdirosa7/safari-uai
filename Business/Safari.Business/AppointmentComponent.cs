using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class AppointmentComponent
    {
        public Appointment Add(Appointment appointment)
        {
            Appointment result = default(Appointment);
            var dac = new AppointmentDAC();

            result = dac.Create(appointment);
            return result;
        }

        public void Update(Appointment appointment)
        {
            var dac = new AppointmentDAC();
            dac.Update(appointment);
        }

        public void Delete(int id)
        {
            var dac = new AppointmentDAC();
            dac.Delete(id);
        }

        public Appointment Find(int id)
        {
            Appointment result = default(Appointment);
            var dac = new AppointmentDAC();

            result = dac.ReadBy(id);
            return result;
        }

        public List<Appointment> List()
        {
            List<Appointment> result = default(List<Appointment>);

            var dac = new AppointmentDAC();
            result = dac.Read();
            return result;
        }
    }
}

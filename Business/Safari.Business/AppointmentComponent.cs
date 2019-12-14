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
            var dac = new AppointmentDAC();

            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("MedicoId", appointment.DoctorId.ToString());
            filters.Add("Fecha", appointment.Date.ToString());

            List<Appointment> appointments = null;

            var data = dac.ReadyByFilters(filters);
            if(data != null && data.Count > 0)
            {
                appointments = new List<Appointment>();
                appointments.AddRange(data);
            }

            filters.Clear();
            filters.Add("PacienteId", appointment.PatientId.ToString());
            filters.Add("Fecha", appointment.Date.ToString());

            data = dac.ReadyByFilters(filters);
            if (data != null && data.Count > 0)
            {
                appointments = new List<Appointment>();
                appointments.AddRange(data);
            }
            
            if(appointments != null && appointments.Count > 0)
            {
                //Puede pasar una de dos, o que el doctor asignado tenga un turno para esa fecha y hora
                //O que lo tenga el paciente
                return appointment;
            }

            Appointment result = default(Appointment);            

            result = dac.Create(appointment);
            return result;
        }

        public void Update(Appointment appointment)
        {
            var dac = new AppointmentDAC();
            dac.Update(appointment);
        }

        public void Delete(Appointment app)
        {
            var dac = new AppointmentDAC();
            dac.LogicDelete(app);
        }

        public Appointment Find(int id)
        {
            Appointment result = default(Appointment);
            var dac = new AppointmentDAC();

            result = dac.ReadBy(id);
            return result;
        }

        public List<Appointment> ToList()
        {
            List<Appointment> result = default(List<Appointment>);

            var dac = new AppointmentDAC();
            result = dac.Read();
            return result;
        }
    }
}

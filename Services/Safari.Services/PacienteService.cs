using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class PacienteService : IPaciente
    {
        PatientComponent bs = new PatientComponent();

        public PacienteService()
        {

        }
        public Patient Add(Patient paciente)
        {
            var model = bs.Add(paciente);
            return model;
        }

        public void Delete(int id)
        {
            bs.Delete(id);
        }

        public Patient Find(int id)
        {
            return bs.Find(id);
        }

        public List<Patient> ToList()
        {
            var pacientes = bs.ToList();
            return pacientes;
        }

        public Patient Update(Patient paciente)
        {
            bs.Update(paciente);
            return paciente;
        }
    }
}

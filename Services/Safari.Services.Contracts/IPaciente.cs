using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IPaciente
    {
        List<Patient> ToList();
        Patient Find(int id);
        Patient Add(Patient patient);
        Patient Update(Patient patient);
        void Delete(int id);
    }
}

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
        Patient Add(Patient especie);
        Patient Update(int id, Patient especie);
        void Delete(int id);
    }
}

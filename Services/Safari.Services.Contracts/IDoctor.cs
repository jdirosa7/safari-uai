using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IDoctor
    {
        List<Doctor> ToList();
        Doctor Find(int id);
        Doctor Add(Doctor especie);
        Doctor Update(int id, Doctor doctor);
        void Delete(int id);
    }
}

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
    public class DoctorService : IDoctor
    {
        DoctorComponent bs = new DoctorComponent();

        public DoctorService()
        {

        }

        public Doctor Add(Doctor doctor)
        {
            var model = bs.Add(doctor);
            return model;
        }

        public void Delete(int id)
        {
            bs.Delete(id);
        }

        public Doctor Find(int id)
        {
            return bs.Find(id);
        }

        public List<Doctor> ToList()
        {
            var especies = bs.List();
            return especies;
        }

        public Doctor Update(int id, Doctor doctor)
        {
            bs.Update(doctor);
            return doctor;
        }
    }
}

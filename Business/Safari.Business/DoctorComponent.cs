﻿using Safari.Data;
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
        DoctorDAC dac = new DoctorDAC();

        public Doctor Add(Doctor doctor)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("NumeroMatricula", doctor.EnrollmentNumber);

            List<Doctor> doctors = dac.ReadyByFilters(filters);

            if(doctors.Count > 0)
            {
                //Existe un doctor ya con esos datos 
                return doctor;
            }

            Doctor result = default(Doctor);

            result = dac.Create(doctor);
            return result;
        }

        public void Update(Doctor doctor)
        {
            dac.Update(doctor);
        }

        public void Delete(int id)
        {
            dac.Delete(id);
        }

        public Doctor Find(int id)
        {
            Doctor result = default(Doctor);

            result = dac.ReadBy(id);
            return result;
        }

        public List<Doctor> List()
        {
            List<Doctor> result = default(List<Doctor>);

            result = dac.Read();
            return result;
        }
    }
}

using Safari.Entities;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class DoctorProcess : ProcessComponent, IDoctor
    {
        public Doctor Add(Doctor doctor)
        {
            var request = new AddDoctorRequest();
            request.Doctor = doctor;
            var response = HttpPost<AddDoctorRequest>("api/doctor/add", request, MediaType.Json);

            return doctor;
        }

        public void Delete(int id)
        {
            var request = new DeleteDoctorRequest();
            request.Id = id;
            var response = HttpPost<DeleteDoctorRequest>("api/doctor/delete", request, MediaType.Json);
        }

        public Doctor Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetDoctorResponse>("api/doctor/getById", dir, MediaType.Json);
            return response.Result;
        }

        public List<Doctor> ToList()
        {
            var response = HttpGet<AllDoctorsResponse>("api/doctor/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Doctor Update(Doctor doctor)
        {
            var request = new UpdateDoctorRequest();
            request.Doctor = doctor;
            var response = HttpPost<UpdateDoctorRequest>("api/doctor/update", request, MediaType.Json);

            return doctor;
        }
    }
}

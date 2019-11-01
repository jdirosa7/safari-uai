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
    public class PatientProcess : ProcessComponent, IPaciente
    {
        public List<Patient> ToList()
        {
            var response = HttpGet<AllPatientsResponse>("api/Patient/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Patient Add(Patient patient)
        {
            var request = new AddPatientRequest();
            request.Patient = patient;
            var response = HttpPost<AddPatientRequest>("api/Patient/add", request, MediaType.Json);

            return patient;
        }

        public Patient Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetPatientResponse>("api/Patient/getById", dir, MediaType.Json);
            return response.Result;
        }

        public Patient Update(Patient patient)
        {
            var request = new UpdatePatientRequest();
            request.Patient = patient;
            var response = HttpPost<UpdatePatientRequest>("api/Patient/update", request, MediaType.Json);

            return patient;
        }

        public void Delete(int id)
        {
            var request = new DeleteSpecieRequest();
            request.Id = id;
            var response = HttpPost<DeleteSpecieRequest>("api/Patient/delete", request, MediaType.Json);
        }
    }
}

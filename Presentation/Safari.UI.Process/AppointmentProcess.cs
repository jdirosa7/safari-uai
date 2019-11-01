using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class AppointmentProcess : ProcessComponent
    {
        public List<Appointment> ToList()
        {
            var response = HttpGet<AllAppointmentsResponse>("api/appointment/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Appointment appointment)
        {
            var request = new AddAppointmentRequest();
            request.Appointment = appointment;
            var response = HttpPost<AddAppointmentRequest>("api/appointment/add", request, MediaType.Json);
        }

        public Appointment Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetAppointmentResponse>("api/appointment/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(Appointment appointment)
        {
            var request = new UpdateAppointmentRequest();
            request.Appointment = appointment;
            var response = HttpPost<UpdateAppointmentRequest>("api/appointment/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteAppointmentRequest();
            request.Id = id;
            var response = HttpPost<DeleteAppointmentRequest>("api/appointment/delete", request, MediaType.Json);
        }
    }
}

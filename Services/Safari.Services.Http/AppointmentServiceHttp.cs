using Safari.Business;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    [RoutePrefix("api/appointment")]
    public class AppointmentServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddAppointmentResponse add(AddAppointmentRequest request)
        {
            try
            {
                var response = new AddAppointmentResponse();
                var bc = new AppointmentComponent();
                response.Result = bc.Add(request.Appointment);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public AllAppointmentsResponse getAll()
        {
            try
            {
                var response = new AllAppointmentsResponse();
                var bc = new AppointmentComponent();
                response.Result = bc.List();

                return response;

            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("getById")]
        public GetAppointmentResponse getById(GetAppointmentRequest request)
        {
            try
            {
                var response = new GetAppointmentResponse();
                var bc = new AppointmentComponent();
                response.Result = bc.Find(request.Appointment.Id);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("update")]
        public void delete(UpdateAppointmentRequest request)
        {
            try
            {
                var response = new UpdateAppointmentResponse();
                var bc = new AppointmentComponent();
                bc.Update(request.Appointment);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public void delete(DeleteAppointmentRequest request)
        {
            try
            {
                var response = new DeleteAppointmentResponse();
                var bc = new AppointmentComponent();
                bc.Delete(request.Id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}

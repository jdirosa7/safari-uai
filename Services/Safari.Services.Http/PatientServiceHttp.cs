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
    [RoutePrefix("api/patient")]
    public class PatientServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddPatientResponse add(AddPatientRequest request)
        {
            try
            {
                var response = new AddPatientResponse();
                var bc = new PatientComponent();
                response.Result = bc.Add(request.Patient);
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
        public AllPatientsResponse getAll()
        {
            try
            {
                var response = new AllPatientsResponse();
                var bc = new PatientComponent();
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
        public GetPatientResponse getById(GetPatientRequest request)
        {
            try
            {
                var response = new GetPatientResponse();
                var bc = new PatientComponent();
                response.Result = bc.Find(request.Patient.Id);
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
        public void delete(UpdatePatientRequest request)
        {
            try
            {
                var response = new UpdatePatientResponse();
                var bc = new PatientComponent();
                bc.Update(request.Patient);
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
        public void delete(DeletePatientRequest request)
        {
            try
            {
                var response = new DeletePatientResponse();
                var bc = new PatientComponent();
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

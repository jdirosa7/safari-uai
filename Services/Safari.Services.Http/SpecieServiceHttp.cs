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
    [RoutePrefix("api/specie")]
    public class SpecieServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddSpecieResponse add(AddSpecieRequest request)
        {
            try
            {
                var response = new AddSpecieResponse();
                var bc = new SpecieComponent();
                response.Result = bc.Add(request.Specie);
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
        public AllSpeciesResponse getAll()
        {
            try
            {
                var response = new AllSpeciesResponse();
                var bc = new SpecieComponent();
                response.Result = bc.ToList();

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
        public GetSpecieResponse getById(GetSpecieRequest request)
        {
            try
            {
                var response = new GetSpecieResponse();
                var bc = new SpecieComponent();
                response.Result = bc.Find(request.Specie.Id);
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
        public void delete(UpdateSpecieRequest request)
        {
            try
            {
                var response = new UpdateSpecieResponse();
                var bc = new SpecieComponent();
                bc.Update(request.Specie);
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
        public void delete(DeleteSpecieRequest request)
        {
            try
            {
                var response = new DeleteSpecieResponse();
                var bc = new SpecieComponent();
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

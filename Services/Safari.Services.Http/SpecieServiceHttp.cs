using Safari.Business;
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
        [Route("addSpecie")]
        public AddSpecieResponse add()
        {
            try
            {
                return null;
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
        public  AllSpeciesResponse getAll()
        {
            try
            {
                var response = new AllSpeciesResponse();
                var bc = new SpecieComponent();
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
    }
}

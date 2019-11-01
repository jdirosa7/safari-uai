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
    [RoutePrefix("api/room")]
    public class RoomServiceHttp : ApiController
    {
        [HttpPost]
        [Route("add")]
        public AddRoomResponse add(AddRoomRequest request)
        {
            try
            {
                var response = new AddRoomResponse();
                var bc = new RoomComponent();
                response.Result = bc.Add(request.Room);
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
        public AllRoomsResponse getAll()
        {
            try
            {
                var response = new AllRoomsResponse();
                var bc = new RoomComponent();
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
        public GetRoomResponse getById(GetRoomRequest request)
        {
            try
            {
                var response = new GetRoomResponse();
                var bc = new RoomComponent();
                response.Result = bc.Find(request.Room.Id);
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
        public void delete(UpdateRoomRequest request)
        {
            try
            {
                var response = new UpdateRoomResponse();
                var bc = new RoomComponent();
                bc.Update(request.Room);
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
        public void delete(DeleteRoomRequest request)
        {
            try
            {
                var response = new DeleteRoomResponse();
                var bc = new RoomComponent();
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

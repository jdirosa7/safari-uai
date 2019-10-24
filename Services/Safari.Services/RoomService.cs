using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Safari.Services.Contracts;
using Safari.Entities;
using Safari.Business;

namespace Safari.Services
{
    [RoutePrefix("rest/Room")]
    public class RoomService : ApiController
    {
        RoomComponent bs = new RoomComponent();
        
        [HttpPost]
        [Route( "Add" )]
        public Room Add(Room room)
        {
            var model = bs.Add(room);
            return model;
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public void Delete(int id)
        {
            bs.Delete(id);
        }

        [HttpGet]
        [Route("Find")]
        public FindResponse Find(int id)
        {
            var response = new FindResponse();
            response.ResultRoom = bs.Find(id);
            return response;
        }

        [HttpGet]
        [Route( "All" )]
        public AllResponse All()
        {
            var response = new AllResponse();
            response.ResultRoom = bs.List();
            return response;
        }

        [HttpPost]
        [Route("Edit")]
        public void Edit(int id, Room room)
        {
            bs.Update(room);
        }
    }
}

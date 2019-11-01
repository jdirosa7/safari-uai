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
        
        
    }
}

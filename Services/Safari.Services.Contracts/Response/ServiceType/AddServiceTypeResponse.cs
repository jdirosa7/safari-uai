using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Http
{
    [DataContract]
    public class AddServiceTypeResponse
    {
        [DataMember]
        public ServiceType Result { get; set; }
    }
}

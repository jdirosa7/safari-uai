
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    [DataContract]
    public class UpdateClientResponse
    {
        [DataMember]
        public Client Result { get; set; }
    }
}

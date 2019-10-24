using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    [DataContract]
    public class FindResponse
    {
        [DataMember]
        public Room ResultRoom { get; set; }

        [DataMember]
        public Client ResultClient { get; set; }

        [DataMember]
        public Species ResultSpecie { get; set; }

        [DataMember]
        public Patient ResultPatient { get; set; }

        [DataMember]
        public Doctor ResultDoctor { get; set; }

        [DataMember]
        public Appointment ResultAppointment { get; set; }
    }
}

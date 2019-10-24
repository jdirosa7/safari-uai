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
    public class AllResponse
    {
        [DataMember]
        public List<Room> ResultRoom { get; set; }

        [DataMember]
        public List<Client> ResultClient { get; set; }

        [DataMember]
        public List<Species> ResultSpecie { get; set; }

        [DataMember]
        public List<Patient> ResultPatient { get; set; }

        [DataMember]
        public List<Doctor> ResultDoctor { get; set; }

        [DataMember]
        public List<Appointment> ResultAppointment { get; set; }
    }
}

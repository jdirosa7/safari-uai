using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Doctor Doctor { get; set; }

        public int DoctorId { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public  ServiceType ServiceType { get; set; }

        public int ServiceTypeId { get; set; }

        [DisplayName("Estado")]
        public string Status { get; set; }


    }
}

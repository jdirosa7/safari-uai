using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Appointment : IEntity, IAudit
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

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime DeletedDate { get; set; }

        public string DeletedBy { get; set; }

        public bool Deleted { get; set; }
    }
}

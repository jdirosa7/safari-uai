using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Tipo de matrícula")]
        [Required]
        [StringLength(50)]
        public string EnrollmentType { get; set; }

        [DisplayName("Número de matrícula")]
        [Required]
        [StringLength(50)]
        public string EnrollmentNumber { get; set; }

        [DisplayName("Apellido")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Especialidad")]
        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Apellido")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public string URL { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required]
        public DateTime BirthDate { get; set; }

        [DisplayName("Domicilio")]
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
    }
}

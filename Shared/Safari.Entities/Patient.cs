using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Patient : IEntity
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }        

        public Species Specie { get; set; }
        
        public int SpecieId { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required]
        public DateTime BirthDate { get; set; }

        [DisplayName("Observación")]
        [Required]
        [StringLength(200)]
        public string Observation { get; set; }
    }
}

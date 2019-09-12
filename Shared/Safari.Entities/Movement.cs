using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Movement : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        public DateTime Date { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public MovementType MovementType { get; set; }

        public int MovementTypeId { get; set; }

        [Required]
        public int Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Price : IEntity
    {
        public int Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public int ServiceTypeId { get; set; }

        [DisplayName("Fecha desde")]
        [Required]
        public DateTime FromDate { get; set; }

        [DisplayName("Fecha hasta")]
        [Required]
        public DateTime ToDate { get; set; }

        [DisplayName("Valor")]
        [Required]
        public int Value { get; set; }
    }
}

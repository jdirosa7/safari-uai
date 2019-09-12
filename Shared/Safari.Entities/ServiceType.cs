using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class ServiceType : IEntity
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

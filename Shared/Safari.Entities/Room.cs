using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Room : IEntity
    {
        public enum RoomTypes
        {
            Recuperación = 1,
            Quirófano = 2,
            Vacunatorio = 3
        }

        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Tipo de sala")]
        [Required]
        [StringLength(50)]
        public string RoomType { get; set; }
    }
}

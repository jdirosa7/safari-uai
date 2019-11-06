using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public interface IAudit
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTime DeletedDate { get; set; }
        string DeletedBy { get; set; }
        bool Deleted { get; set; }
    }
}

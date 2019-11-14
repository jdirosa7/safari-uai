using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class MovementTypeDAC : DataAccessComponent, IRepository<MovementType>
    {
        public MovementType Create(MovementType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovementType> Read()
        {
            throw new NotImplementedException();
        }

        public MovementType ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovementType> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }

        public void Update(MovementType entity)
        {
            throw new NotImplementedException();
        }
    }
}

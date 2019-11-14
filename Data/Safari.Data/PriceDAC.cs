using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class PriceDAC : DataAccessComponent, IRepository<Price>
    {
        public Price Create(Price entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Price> Read()
        {
            throw new NotImplementedException();
        }

        public Price ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Price> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }

        public void Update(Price entity)
        {
            throw new NotImplementedException();
        }
    }
}

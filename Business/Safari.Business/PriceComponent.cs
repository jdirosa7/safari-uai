using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class PriceComponent
    {
        public Price Add(Price price)
        {
            Price result = default(Price);
            var priceDAC = new PriceDAC();

            result = priceDAC.Create(price);
            return result;
        }

        public void Update(Price price)
        {
            var priceDAC = new PriceDAC();
            priceDAC.Update(price);
        }

        public void Delete(int id)
        {
            var priceDAC = new PriceDAC();
            priceDAC.Delete(id);
        }

        public List<Price> ToList()
        {
            List<Price> result = default(List<Price>);

            var priceDAC = new PriceDAC();
            result = priceDAC.Read();
            return result;
        }
    }
}

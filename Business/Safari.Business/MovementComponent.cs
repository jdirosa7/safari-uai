using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class MovementComponent
    {
        public Movement Add(Movement movement)
        {
            Movement result = default(Movement);
            var dac = new MovementDAC();

            result = dac.Create(movement);
            return result;
        }

        public void Update(Movement movement)
        {
            var dac = new MovementDAC();
            dac.Update(movement);
        }

        public void Delete(int id)
        {
            var dac = new MovementDAC();
            dac.Delete(id);
        }

        public List<Movement> ToList()
        {
            List<Movement> result = default(List<Movement>);

            var dac = new MovementDAC();
            result = dac.Read();
            return result;
        }
    }
}

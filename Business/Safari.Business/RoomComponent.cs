using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class RoomComponent
    {
        RoomDAC dac = new RoomDAC();

        public Room Add(Room room)
        {
            Room result = default(Room);
            
            result = dac.Create(room);
            return result;
        }

        public void Update(Room room)
        {
            dac.Update(room);
        }

        public void Delete(int id)
        {
            dac.Delete(id);
        }

        public Room Find(int id)
        {
            return dac.ReadBy(id);
        }

        public List<Room> List()
        {
            List<Room> result = default(List<Room>);

            result = dac.Read();
            return result;
        }
    }
}

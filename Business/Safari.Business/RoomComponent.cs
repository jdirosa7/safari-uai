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
        public Room Add(Room room)
        {
            Room result = default(Room);
            var roomDAC = new RoomDAC();

            result = roomDAC.Create(room);
            return result;
        }

        public void Update(Room room)
        {
            var roomDAC = new RoomDAC();
            roomDAC.Update(room);
        }

        public void Delete(int id)
        {
            var roomDAC = new RoomDAC();
            roomDAC.Delete(id);
        }

        public List<Room> List()
        {
            List<Room> result = default(List<Room>);

            var roomDAC = new RoomDAC();
            result = roomDAC.Read();
            return result;
        }
    }
}

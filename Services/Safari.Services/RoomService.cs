using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class RoomService : IRoom
    {
        RoomComponent bs = new RoomComponent();

        public RoomService()
        {

        }

        public Room Add(Room room)
        {
            var model = bs.Add(room);
            return model;
        }

        public void Delete(int id)
        {
            bs.Delete(id);
        }

        public Room Find(int id)
        {
            return bs.Find(id);
        }

        public List<Room> ToList()
        {
            var rooms = bs.List();
            return rooms;
        }

        public Room Update(int id, Room room)
        {
            bs.Update(room);
            return room;
        }
    }
}

using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IRoom
    {
        List<Room> ToList();
        Room Find(int id);
        Room Add(Room room);
        Room Update(int id, Room room);
        void Delete(int id);
    }
}

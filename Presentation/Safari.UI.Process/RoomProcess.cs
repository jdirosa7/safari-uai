using Safari.Entities;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class RoomProcess : ProcessComponent
    {
        public List<Room> ToList()
        {
            var response = HttpGet<AllRoomsResponse>("api/room/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Room room)
        {
            var request = new AddRoomRequest();
            request.Room = room;
            var response = HttpPost<AddRoomRequest>("api/room/add", request, MediaType.Json);
        }

        public Room Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetRoomResponse>("api/room/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(Room room)
        {
            var request = new UpdateRoomRequest();
            request.Room = room;
            var response = HttpPost<UpdateRoomRequest>("api/room/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteRoomRequest();
            request.Id = id;
            var response = HttpPost<DeleteRoomRequest>("api/room/delete", request, MediaType.Json);
        }
    }
}

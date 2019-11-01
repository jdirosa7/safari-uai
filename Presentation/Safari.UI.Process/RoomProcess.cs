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
            var response = HttpGet<AllRoomsResponse>("api/specie/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Room room)
        {
            var request = new AddRoomRequest();
            request.Room = room;
            var response = HttpPost<AddRoomRequest>("api/specie/add", request, MediaType.Json);
        }

        public Room Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetRoomResponse>("api/specie/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(Room room)
        {
            var request = new UpdateRoomRequest();
            request.Room = room;
            var response = HttpPost<UpdateRoomRequest>("api/specie/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteSpecieRequest();
            request.Id = id;
            var response = HttpPost<DeleteSpecieRequest>("api/specie/delete", request, MediaType.Json);
        }
    }
}

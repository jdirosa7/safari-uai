using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class RoomProcess : ProcessComponent
    {
        public List<Room> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Room/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultRoom;
        }

        public void AddRoom(Room room)
        {

            ProcessComponent.HttpPost<Room>("rest/Room/Add", room, MediaType.Json);
        }

        public Room FindRoom(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            var response = HttpGet<FindResponse>("rest/Room/Find", dic, MediaType.Json);
            return response.ResultRoom;

        }

        public void EditRoom(Room Client)
        {
            ProcessComponent.HttpPost<Room>("rest/Room/Edit", Client, MediaType.Json);
        }

        public void DeleteRoom(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            ProcessComponent.HttpGet<Room>("rest/Room/Remove/{id}", dic, MediaType.Json);
        }
    }
}

using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class ClientProcess : ProcessComponent
    {
        public List<Client> ToList()
        {
            var response = HttpGet<AllClientsResponse>("api/client/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Client client)
        {
            var request = new AddClientRequest();
            request.Client = client;
            var response = HttpPost<AddClientRequest>("api/client/add", request, MediaType.Json);
        }

        public Client Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetClientResponse>("api/client/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(Client client)
        {
            var request = new UpdateClientRequest();
            request.Client = client;
            var response = HttpPost<UpdateClientRequest>("api/client/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteClientRequest();
            request.Id = id;
            var response = HttpPost<DeleteClientRequest>("api/client/delete", request, MediaType.Json);
        }
    }
}

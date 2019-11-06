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
    public class ServiceTypeProcess : ProcessComponent
    {
        public List<ServiceType> ToList()
        {
            var response = HttpGet<AllServiceTypesResponse>("api/room/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(ServiceType serviceType)
        {
            var request = new AddServiceTypeRequest();
            request.ServiceType = serviceType;
            var response = HttpPost<AddServiceTypeRequest>("api/room/add", request, MediaType.Json);
        }

        public ServiceType Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetServiceTypeResponse>("api/room/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(ServiceType serviceType)
        {
            var request = new UpdateServiceTypeRequest();
            request.ServiceType = serviceType;
            var response = HttpPost<UpdateServiceTypeRequest>("api/room/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteServiceTypeRequest();
            request.Id = id;
            var response = HttpPost<DeleteServiceTypeRequest>("api/room/delete", request, MediaType.Json);
        }
    }
}

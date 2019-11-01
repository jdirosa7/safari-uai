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
    public class SpecieProcess : ProcessComponent
    {
        public List<Species> ToList()
        {
            var response = HttpGet<AllSpeciesResponse>("api/specie/getAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Species specie)
        {
            var request = new AddSpecieRequest();
            request.Specie = specie;
            var response = HttpPost<AddSpecieRequest>("api/specie/add", request, MediaType.Json);            
        }

        public Species Find(int id)
        {
            Dictionary<string, object> dir = new Dictionary<string, object>();
            dir.Add("Id", id);
            var response = HttpGet<GetSpecieResponse>("api/specie/getById", dir, MediaType.Json);
            return response.Result;
        }

        public void Update(Species specie)
        {
            var request = new UpdateSpecieRequest();
            request.Specie = specie;
            var response = HttpPost<UpdateSpecieRequest>("api/specie/update", request, MediaType.Json);
        }

        public void Delete(int id)
        {
            var request = new DeleteSpecieRequest();
            request.Id = id;
            var response = HttpPost<DeleteSpecieRequest>("api/specie/delete", request, MediaType.Json);
        }
    }
}

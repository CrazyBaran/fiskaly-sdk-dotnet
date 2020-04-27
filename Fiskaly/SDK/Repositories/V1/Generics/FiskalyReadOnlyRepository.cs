using System;
using System.Collections.Generic;
using System.Text;
using Fiskaly.Models.V1.Generics;
using Newtonsoft.Json;

namespace Fiskaly.Repositories.V1.Generics
{
    public abstract class FiskalyReadOnlyRepository<TResponse> : IFiskalyReadOnlyRepository<TResponse> where TResponse : IResponse
    {
        protected readonly FiskalyHttpClient _fiskalyHttpClient;
        protected readonly string _resource;
        protected FiskalyReadOnlyRepository(FiskalyHttpClient fiskalyHttpClient, string resource)
        {
            _fiskalyHttpClient = fiskalyHttpClient;
            _resource = resource;
        }
        public IEnumerableResponse<TResponse> List()
        {
            var response = _fiskalyHttpClient.Request("GET", _resource, null, null, null);
            return JsonConvert.DeserializeObject<IEnumerableResponse<TResponse>>(response.Body);
        }

        public TResponse Retrieve(Guid id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> RetrieveMetadata(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

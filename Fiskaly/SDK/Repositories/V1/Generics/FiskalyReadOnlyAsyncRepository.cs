using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Repositories.V1.Generics
{
    public abstract class FiskalyReadOnlyAsyncRepository<TResponse> : IFiskalyReadOnlyAsyncRepository<TResponse> where TResponse : IResponse
    {
        private readonly FiskalyHttpClient _fiskalyHttpClient;
        private readonly string _resource;

        protected FiskalyReadOnlyAsyncRepository(FiskalyHttpClient fiskalyHttpClient, string resource)
        {
            _fiskalyHttpClient = fiskalyHttpClient;
            _resource = resource;
        }
        public Task<IEnumerableResponse<TResponse>> ListAsync()
        {
            throw new NotImplementedException();
            var response = _fiskalyHttpClient.Request("GET", _resource, null, null, null);
        }

        public Task<TResponse> RetrieveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, string>> RetrieveMetadataAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

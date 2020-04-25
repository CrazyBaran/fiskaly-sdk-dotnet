using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Repositories.V1.Generics
{
    public interface IFiskalyReadOnlyAsyncRepository<TResponse> where TResponse : IResponse
    {
        Task<IEnumerableResponse<TResponse>> ListAsync();
        Task<TResponse> RetrieveAsync(Guid id);
        Task<Dictionary<string, string>> RetrieveMetadataAsync(Guid id);
    }
}

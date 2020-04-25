using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Repositories.V1.Generics
{
    public interface IFiskalyAsyncRepository<TRequest, TResponse> : IFiskalyReadOnlyAsyncRepository<TResponse> where TRequest : IRequest where TResponse : IResponse
    {
        Task<TResponse> CreateOrUpdateAsync(Guid id, TRequest request);
        Task<Dictionary<string, string>> UpdateMetadataAsync(Guid id, Dictionary<string, string> metadata);
    }
}

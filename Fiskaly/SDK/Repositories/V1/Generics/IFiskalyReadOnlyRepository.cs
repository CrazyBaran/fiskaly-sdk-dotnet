using System;
using System.Collections.Generic;
using System.Text;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Repositories.V1.Generics
{
    public interface IFiskalyReadOnlyRepository<TResponse> where TResponse : IResponse
    {
        IEnumerableResponse<TResponse> List();
        TResponse Retrieve(Guid id);
        Dictionary<string, string> RetrieveMetadata(Guid id);
    }
}

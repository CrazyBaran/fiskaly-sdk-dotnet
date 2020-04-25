using System;
using System.Collections.Generic;
using System.Text;

namespace Fiskaly.Models.V1.Generics
{
    public interface IEnumerableResponse<TResponse> : IResponse where TResponse : IResponse
    {
        IEnumerable<TResponse> Data { get; set; }
        long Count { get; set; }
    }
}

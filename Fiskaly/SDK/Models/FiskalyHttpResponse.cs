using System.Collections.Generic;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Client.Models
{
    public class FiskalyHttpResponse
    {
        public int Status { get; set; }
        public string Reason { get; set; }
        public byte[] Body { get; set; }
        public Dictionary<string, string[]> Headers { get; set; }
    }

    public class FiskalyHttpResponse<TResponse> : FiskalyHttpResponse where TResponse : IResponse
    {
        public TResponse Object { get; set; }
    }
}

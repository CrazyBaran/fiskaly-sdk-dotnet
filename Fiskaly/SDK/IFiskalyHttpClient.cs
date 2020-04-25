using System.Collections.Generic;
using Fiskaly.Client;
using Fiskaly.Client.Models;

namespace Fiskaly
{
    public interface IFiskalyHttpClient
    {
        FiskalyHttpResponse Request(string method, string path, byte[] body, Dictionary<string, string> headers, Dictionary<string, string> query);
        ClientConfiguration ConfigureClient(ClientConfiguration configuration);
        Models.Version Version();
    }
}
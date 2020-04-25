using System;
using System.Collections.Generic;
using System.Text;

namespace Fiskaly.Models.V1.Generics
{
    public interface IHaveMetadata
    {
        Dictionary<string, string> Metadata { get; set; }
    }
}

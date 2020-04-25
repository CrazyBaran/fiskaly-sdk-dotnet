using System;
using System.Collections.Generic;
using System.Text;
using Fiskaly.Models.V1.Generics;

namespace Fiskaly.Models.V1.Transactions
{
    public class Transaction : IResponse, IHaveMetadata
    {
        public string Description { get; set; }
        public State State { get; set; }
        public DateTime TimeCreation { get; set; }
        public DateTime TimeInit { get; set; }
        public DateTime TimeDisable { get; set; }
        public string Certificate { get; set; }
        public string CertificateSerial { get; set; }
        public string PublicKey { get; set; }
        public long SignatureCounter { get; set; }
        public string SignatureAlgorithm { get; set; }
        public string SignatureTimestampFormat { get; set; }
        public long TransactionCounter { get; set; }
        public string TransactionDataEncoding { get; set; }
        public string _type { get; set; }
        public string _env { get; set; }
        public string _version { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    public enum State
    {
        UNINITIALIZED,
        INITIALIZED,
        DISABLED
    }
}

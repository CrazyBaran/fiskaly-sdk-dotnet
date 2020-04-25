using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fiskaly.Client
{
    public enum DebugLevel
    {
        NO_OUTPUT = -1,
        ERRORS_ONLY = 0,
        ERRORS_AND_WARNINGS = 1,
        EVERYTHING = 2
    }

    public class ClientConfiguration
    {
        public DebugLevel DebugLevel { get; set; }
        public string DebugFile { get; set; }
        public int ClientTimeout { get;set; }
        public int SmaersTimeout { get; set; }
    }

    public abstract class AbstractClient
    {
        protected static bool Is64BitSystem = IntPtr.Size == 8;

        protected const string SYMBOL_INVOKE = "_fiskaly_client_invoke";
        protected const string SYMBOL_FREE = "_fiskaly_client_free";

        protected const string LIB_PREFIX = "com.fiskaly.client";
        protected const string CLIENT_VERSION = Constants.CLIENT_VERSION;

        protected abstract IntPtr PerformInvokeForArchitecture(byte[] request);
        protected abstract void PerformFreeForArchitecture(IntPtr allocatedMemory);


        public string Invoke([In] byte[] request)
        {
            IntPtr resultPtr = PerformInvokeForArchitecture(request);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            PerformFreeForArchitecture(resultPtr);

            return result;
        }

#if NET40


#elif NETSTANDARD2_0
        protected abstract Task<IntPtr> PerformInvokeForArchitectureAsync(byte[] request);
        protected abstract Task PerformFreeForArchitectureAsync(IntPtr resultPtr);

        public async Task<string> InvokeAsync([In] byte[] request)
        {
            IntPtr resultPtr = await PerformInvokeForArchitectureAsync(request);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            PerformFreeForArchitectureAsync(resultPtr);

            return result;
        }
#endif

    }
}

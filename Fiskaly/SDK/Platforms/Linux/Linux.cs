using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fiskaly.Client
{
    public class LinuxClient : AbstractClient
    {
        private const string PLATFORM = "linux";
        private const string EXTENSION = ".so";

        private const string LIB_64 = LIB_PREFIX + "-" + PLATFORM + "-amd64-" + CLIENT_VERSION + EXTENSION;
        private const string LIB_32 = LIB_PREFIX + "-" + PLATFORM + "-386-" + CLIENT_VERSION + EXTENSION;


        [DllImport(LIB_32, EntryPoint = SYMBOL_FREE)]
        internal static extern void Free32(IntPtr response);

        [DllImport(LIB_64, EntryPoint = SYMBOL_FREE)]
        internal static extern void Free64(IntPtr response);

        [DllImport(LIB_32, EntryPoint = SYMBOL_INVOKE)]
        internal static extern IntPtr Invoke32([In] byte[] request);

        [DllImport(LIB_64, EntryPoint = SYMBOL_INVOKE)]
        internal static extern IntPtr Invoke64([In] byte[] request);

        protected override void PerformFreeForArchitecture(IntPtr allocatedMemory)
        {
            if (Is64BitSystem)
            {
                Free64(allocatedMemory);
            } else
            {
                Free32(allocatedMemory);
            }
        }

        protected override IntPtr PerformInvokeForArchitecture(byte[] request)
        {
            if (Is64BitSystem)
            {
                return Invoke64(request);
            }

            return Invoke32(request);
        }

#if NET40


#elif NETSTANDARD2_0
        protected override Task<IntPtr> PerformInvokeForArchitectureAsync(byte[] request)
        {
            throw new NotImplementedException();
        }

        protected override Task PerformFreeForArchitectureAsync(IntPtr resultPtr)
        {
            throw new NotImplementedException();
        }

#endif
    }
}
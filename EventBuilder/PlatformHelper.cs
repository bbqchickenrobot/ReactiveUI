using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBuilder
{
    public static class PlatformHelper
    {
        private static readonly Lazy<bool> _IsRunningOnMono = new Lazy<bool>(() => Type.GetType("Mono.Runtime") != null);

        public static bool IsRunningOnMono()
        {
            return _IsRunningOnMono.Value;
        }
    }
}

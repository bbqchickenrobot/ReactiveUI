using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventBuilder.Platforms
{
    public class Mac
    {
        private readonly List<string> _assemblies = new List<string>();

        public Mac()
        {
            if (PlatformHelper.IsRunningOnMono())
            {
                _assemblies.Add("/Library/Frameworks/Xamarin.Mac.framework/Versions/Current/lib/mono/XamMac.dll");

                _assemblies.Add(
                    Directory.GetFiles(
                        @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5",
                        "*.dll", SearchOption.AllDirectories).Last()
                    );
            }
            else
            {
                Log.Warning("Building events for Xamarin.Mac on Windows is not implemented yet.");
            }
        }

        public IReadOnlyList<string> Assemblies => _assemblies.AsReadOnly();
    }
}
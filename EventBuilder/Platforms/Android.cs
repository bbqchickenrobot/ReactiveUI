using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventBuilder.Platforms
{
    public class Android
    {
        private readonly List<string> _assemblies = new List<string>();

        public Android()
        {
            if (PlatformHelper.IsRunningOnMono())
            {
                var assemblies =
                    Directory.GetFiles(
                        @"/Library/Frameworks/Xamarin.Android.framework/Libraries/xbuild-frameworks/MonoAndroid",
                        "Mono.Android.dll", SearchOption.AllDirectories);

                var latestVersion = assemblies.Last();
                _assemblies.Add(latestVersion);
            }
            else
            {
                var assemblies =
                    Directory.GetFiles(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\MonoAndroid",
                        "Mono.Android.dll", SearchOption.AllDirectories);

                var latestVersion = assemblies.Last();
                _assemblies.Add(latestVersion);
            }
        }

        public IReadOnlyList<string> Assemblies => _assemblies.AsReadOnly();
    }
}
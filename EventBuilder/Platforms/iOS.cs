using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventBuilder.Platforms
{
    // ReSharper disable once InconsistentNaming
    public class iOS
    {
        private readonly List<string> _assemblies = new List<string>();

        public iOS()
        {
            if (PlatformHelper.IsRunningOnMono())
            {
                _assemblies.Add(
                    @"/Library/Frameworks/Xamarin.iOS.framework/Versions/Current/lib/mono/Xamarin.iOS/Xamarin.iOS.dll");
            }
            else
            {
                var assemblies =
                    Directory.GetFiles(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Xamarin.iOS",
                        "Xamarin.iOS.dll", SearchOption.AllDirectories);

                var latestVersion = assemblies.Last();
                _assemblies.Add(latestVersion);
            }
        }

        public IReadOnlyList<string> Assemblies => _assemblies.AsReadOnly();
    }
}
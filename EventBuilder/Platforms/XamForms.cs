using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet;

namespace EventBuilder.Platforms
{
    public class XamForms
    {
        private readonly List<string> _assemblies = new List<string>();

        public XamForms()
        {
            var repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            var packageUnzipPath = Environment.CurrentDirectory;

            var packageManager = new PackageManager(repo, packageUnzipPath);
            packageManager.InstallPackage("Xamarin.Forms");

            var xamarinForms =
                Directory.GetFiles(packageUnzipPath,
                    "Xamarin.Forms.Core.dll", SearchOption.AllDirectories);

            var latestVersion = xamarinForms.Last();
            _assemblies.Add(latestVersion);

            if (PlatformHelper.IsRunningOnMono())
            {
                var assemblies =
                    Directory.GetFiles(@"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/xbuild-frameworks/.NETPortable/v4.5/Profile/Profile111",
                        "*.dll", SearchOption.AllDirectories);

                _assemblies.AddRange(assemblies);
            }
            else
            {
                var assemblies =
                    Directory.GetFiles(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile111",
                        "*.dll", SearchOption.AllDirectories);

                _assemblies.AddRange(assemblies);
            }
        }

        public IReadOnlyList<string> Assemblies => _assemblies.AsReadOnly();
    }
}
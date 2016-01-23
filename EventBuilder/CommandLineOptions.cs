using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace EventBuilder
{
    public enum AutoPlatform
    {
        None,
        Android,
        iOS,
        Mac,
        XamForms,
        UWP,
        WinRT,
        WP8,
        WP81,
        WPA81,
        All
    }

    public class CommandLineOptions
    {
        [ParserState]
        public IParserState LastParserState { get; set; }

        [Option('p', "platform", Required = true, HelpText = "Platform to automatically generate. Possible options include: NONE, ANDROID, IOS, MAC, UWP, WINRT, WP8, WP81, WPA81, XAMFORMS, ALL")]
        public AutoPlatform Platform { get; set; }

        [Option('t', "template", Required = false, HelpText = "Specify another mustache template other than the default.")]
        public string Template { get; set; }

        // Manual generation using the specified assemblies. Use with --platform=NONE.
        [ValueList(typeof(List<string>))]
        public IList<string> Assemblies { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
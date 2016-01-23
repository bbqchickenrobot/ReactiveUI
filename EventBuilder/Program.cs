using System;
using System.Diagnostics;
using System.Linq;
using CommandLine;
using Serilog;

namespace EventBuilder
{
    internal class Program
    {
        private static string _mustacheTemplate = "DefaultTemplate.mustache";

        /// <summary>
        ///     The exit/return code (aka %ERRORLEVEL%) on application exit.
        /// </summary>
        public enum ExitCode
        {
            Success = 0,
            Error = 1
        }

        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose().WriteTo.File("EventBuilder.log")
                .MinimumLevel.Error().WriteTo.ColoredConsole()
                .CreateLogger();

            var options = new CommandLineOptions();

            // allow app to be debugged in visual studio.
            if (Debugger.IsAttached)
            {
                //args = "--help ".Split(' ');
                args = "--platform=none".Split(' ');
                //args = "--platform=none 'C:\\1' 'C:\\2' ".Split(' ');
            }

            // Parse in 'strict mode'; i.e. success or quit
            if (Parser.Default.ParseArgumentsStrict(args, options))
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(options.Template))
                    {
                        _mustacheTemplate = options.Template;
                    }

                    switch (options.Platform)
                    {
                        case AutoPlatform.None:
                            if (!options.Assemblies.Any())
                            {
                                throw new Exception("Assemblies to be used for manual generation were not specified.");
                            }
                            Log.Warning("None");
                            break;

                        case AutoPlatform.Android:
                        case AutoPlatform.iOS:
                        case AutoPlatform.Mac:
                        case AutoPlatform.XamForms:
                        case AutoPlatform.UWP:
                        case AutoPlatform.WinRT:
                        case AutoPlatform.WP8:
                        case AutoPlatform.WP81:
                        case AutoPlatform.WPA81:
                        case AutoPlatform.All:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    Environment.Exit((int) ExitCode.Success);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex.ToString());
                }
            }

            Environment.Exit((int) ExitCode.Error);
        }
    }
}
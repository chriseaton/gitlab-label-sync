using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging.Filter;
using GLS.Command;

namespace GLS {

    class Program {

        internal static ILogger Log = null;

        /// <summary>
        /// Entry point for the program CLI.
        /// </summary>
        public static void Main(string[] args) {
            LogLevel ll = LogLevel.Error;
            //setup logger 
            args = Parser.FilterLogLevel(args, out ll);
            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole(ll)
                .AddDebug();
            Log = loggerFactory.CreateLogger("GitLab Label Sync");
            //parse CLI arguments
            ICommandAction action = Parser.Parse(args);
            //perform action
            if (action != null) {
                Log.LogDebug("Running action {0}.", action.Action);
                action.Run();
            } 
            loggerFactory.Dispose();
            Console.WriteLine();
        }
    }

}

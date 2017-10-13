using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using System.Security;

namespace GLS.Command {

    public static class Parser {

        #region " Static Methods "

        /// <summary>
        /// Extracts the logging level from the CLI arguments, if present.
        /// This argument must be the first in the array and must be a valid LogLevel enum name.
        /// </summary>
        /// <param name="args">The CLI arguments.</param>
        /// <param name="logLevel">The discovered LogLevel value (defaults to "Error").</param>
        /// <returns>The CLI argument array minus the log level argument.</returns>
        public static string[] FilterLogLevel(string[] args, out LogLevel logLevel) {
            //check for log-level
            if (args != null && args.Length > 0) {
                string level = args[0];
                if (Enum.TryParse<LogLevel>(level, true, out logLevel)) {
                    if (args.Length > 1) {
                        string[] adj = new string[args.Length - 1];
                        Array.Copy(args, 1, adj, 0, adj.Length);
                        args = adj;
                    } else {
                        return args;
                    }
                } else {
                    logLevel = LogLevel.Error;
                }
            } else {
                logLevel = LogLevel.Error;
            }
            return args;
        }

        /// <summary>
        /// Parses the CLI arguments and returns the appropriate command action.
        /// </summary>
        /// <param name="args">The CLI arguments.</param>
        /// <returns>Returns the command action object if parsed correctly, otherwise, null is returned.</returns>
        public static ICommandAction Parse(string[] args) {
            ICommandAction result = null;
            Program.Log.LogDebug("Parsing Args: [{0}].", String.Join("], [", args));
            if (args != null && args.Length > 0) {
                string action = args[0];
                //parse for actions
                if (Regex.Matches(action, @"alter", RegexOptions.IgnoreCase).Count > 0) {
                    return new AlterAction();
                } else if (Regex.Matches(action, @"copy|cp", RegexOptions.IgnoreCase).Count > 0) {
                    return new CopyAction();
                } else if (Regex.Matches(action, @"create|add|touch", RegexOptions.IgnoreCase).Count > 0) {
                    return new CreateAction();
                } else if (Regex.Matches(action, @"(--)?help|/\?", RegexOptions.IgnoreCase).Count > 0) {
                    return new HelpAction();
                } else if (Regex.Matches(action, @"list|ls", RegexOptions.IgnoreCase).Count > 0) {
                    return new ListAction();
                } else if (Regex.Matches(action, @"merge", RegexOptions.IgnoreCase).Count > 0) {
                    return new MergeAction();
                } else if (Regex.Matches(action, @"register|reg", RegexOptions.IgnoreCase).Count > 0) {
                    result = ParseRegisterAction(args);
                } else if (Regex.Matches(action, @"remove|rm", RegexOptions.IgnoreCase).Count > 0) {
                    return new RemoveAction();
                }
                if (result == null) {
                    Console.WriteLine("Unable to parse arguments for action \"{0}\".", action);
                }
            } else {
                Console.WriteLine("No action has been specified.");
            }
            if (result == null) {
                Console.WriteLine("Use the \"--help\" argument to find more information.");
            }
            return result;
        }

        /// <summary>
        /// Parses the arguments for the Register action.
        /// </summary>
        /// <param name="args">The CLI arguments.</param>
        /// <returns>Returns the command action object if parsed correctly, otherwise, null is returned.</returns>
        private static ICommandAction ParseRegisterAction(string[] args) {
            if (args.Length >= 3 && args.Length <= 4) {
                args[1] = args[1].Trim();
                //create secure token
                SecureString token = new SecureString();
                Array.ForEach(args[2].ToCharArray(), token.AppendChar);
                token.MakeReadOnly();
                args[2] = String.Empty;
                //check for save option
                bool? save = null;
                if (args.Length == 4) {
                    if (Regex.Matches(args[3], @"(--)?save", RegexOptions.IgnoreCase).Count > 0) {
                        save = true;
                    }
                } else {
                    save = false;
                }
                if (save.HasValue) {
                    if (Uri.IsWellFormedUriString(args[1], UriKind.Absolute)) {
                        Program.Log.LogDebug("Register: {0} (Save={1})", args[1], save.Value);
                        return new RegisterAction(args[1], token, save.Value);
                    } else {
                        Program.Log.LogError("Expected a well-formed URI but found \"{0}\".", args[1]);
                    }
                } else {
                    Program.Log.LogError("Expected \"--save\" or empty but found \"{0}\".", args[3]);
                }
            }
            return null;
        }

        #endregion

    }

}
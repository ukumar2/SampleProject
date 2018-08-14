using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sample.Project.Logger
{
    public class LogInformation
    {
        public LogInformation()
        {
            //constructor
        }

        /// <summary>
        /// Logs error
        /// </summary>
        /// <param name="errorMsg">string message</param>
        public static void LogError(string errorMsg)
        {
            LogMsg(LogErrorType.Error, errorMsg);
        }

        /// <summary>
        /// Logs warning
        /// </summary>
        /// <param name="warningMsg">string message</param>
        public static void LogWarning(string warningMsg)
        {
            LogMsg(LogErrorType.Warning, warningMsg);
        }

        /// <summary>
        /// Logs information
        /// </summary>
        /// <param name="informationMsg">string type informationMsg</param>
        public static void LogInfor(string informationMsg)
        {
            LogMsg(LogErrorType.Information, informationMsg);
        }

        /// <summary>
        /// write log to system's event viewer
        /// </summary>
        /// <param name="errorType">error type</param>
        /// <param name="message">error message</param>
        private static void LogMsg(LogErrorType errorType, string message)
        {
            if (!EventLog.SourceExists("SampleProjectConsoleApp"))
                EventLog.CreateEventSource("SampleProjectConsoleApp", "Application");

            EventLog log = new EventLog("Application");
            log.Source = "SampleProjectConsoleApp";

            switch (errorType)
            {
                case LogErrorType.Error:
                    log.WriteEntry(message, EventLogEntryType.Error);
                    break;
                case LogErrorType.Warning:
                    log.WriteEntry(message, EventLogEntryType.Warning);
                    break;
                case LogErrorType.Information:
                    log.WriteEntry(message, EventLogEntryType.Information);
                    break;
                default:
                    log.WriteEntry(message, EventLogEntryType.Information);
                    break;
            }
        }

    }
}

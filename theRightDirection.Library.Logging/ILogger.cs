using System;

namespace theRightDirection.Library.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// log the app.config or web.config settings to the logfile
        /// </summary>
        void LogApplicationSettings();

        /// <summary>
        /// Logs a message with the debug level.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogDebug(string message);

        /// <summary>
        /// Logs a message with the debug level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        void LogDebug(string format, params object[] values);

        /// <summary>
        /// Logs a message with the info level.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInfo(string message);

        /// <summary>
        /// Logs a message with the info level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        void LogInfo(string format, params object[] values);

        /// <summary>
        /// Logs a message with the error level.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogError(string message);

        /// <summary>
        /// Logs a message with the error level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        void LogError(string format, params object[] values);

        /// <summary>
        /// Logs a message with the warn level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        void LogWarn(string format, params object[] values);

        /// <summary>
        /// Logs a message with the warn level.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarn(string message);

        /// <summary>
        /// Logs the object information with all the values of all properties in the object
        /// </summary>
        /// <param name="o">The object</param>
        //        void LogObjectInformation(Object o);

        /// <summary>
        /// Logs the exception information which will log at error level and the stacktrace
        /// </summary>
        /// <param name="e">The exception</param>
        void LogException(Exception e);

        string FullLogFileName { get; }

        bool ShowStackTrace { get; set; }
    }
}
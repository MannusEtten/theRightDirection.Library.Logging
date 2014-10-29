using System;

namespace theRightDirection.Library.Logging
{
    /// <summary>
    /// Levels of importance of a log message
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// Debug
        /// </summary>
        Debug,
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// Warn
        /// </summary>
        Warn,
        /// <summary>
        /// Error
        /// </summary>
        Error,
        /// <summary>
        /// Fatal
        /// </summary>
        Fatal
    }
}
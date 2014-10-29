using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using theRightDirection.Library.Extensions;
using log4net;
using log4net.Config;

namespace theRightDirection.Library.Logging
{
    public sealed class Logger : ILogger
    {
        #region Fields (2)

        private static Logger _instance;
        private static ILog _log;
        private static bool _debugIsEnabled;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Private Constructor is deliberate (for Singleton Pattern)
        /// </summary>
        private Logger()
        {
            _debugIsEnabled = IsDebug();
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Gets the name of the log file which is be default the name of the assembly
        /// </summary>
        /// <value>The name of the log file</value>
        public string LogFileName
        {
            get
            {
                return string.Format("{0}.Logging", GetAssemblyName());
            }
        }

        public bool ShowStackTrace { get; set; }

        #endregion Properties

        #region Methods (3)

        // Public Methods (1) 

        /// <summary>
        /// Gets the logger with the given logfile name.
        /// </summary>
        /// <returns>a pointer to an instance of the logger</returns>
        public static ILogger GetLogger()
        {
            if (_instance == null)
            {
                _instance = new Logger();
                _instance.ReadConfiguration();
                _log = LogManager.GetLogger(_instance.GetType());
                _instance.ShowStackTrace = true;
            }
            return _instance;
        }

        private bool IsDebug()
        {
            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(DebuggableAttribute), false);
            if ((customAttributes != null) && (customAttributes.Length == 1))
            {
                DebuggableAttribute attribute = customAttributes[0] as DebuggableAttribute;
                return (attribute.IsJITOptimizerDisabled && attribute.IsJITTrackingEnabled);
            }
            return false;
        }

        // Private Methods (1) 

        private string GetAssemblyName()
        {
            if (Assembly.GetEntryAssembly() != null)
            {
                return Assembly.GetEntryAssembly().GetName().Name;
            }
            return Assembly.GetCallingAssembly().GetName().Name;
        }

        // Internal Methods (1) 

        internal static void DestroyLogger()
        {
            _instance = null;
        }

        #endregion Methods

        #region Public Methods

        /// <summary>
        /// log the app.config or web.config settings to the logfile
        /// </summary>
        public void LogApplicationSettings()
        {
            LogInfo("----- application configuration -----");
            NameValueCollection applicationSettings = ConfigurationManager.AppSettings;
            if (applicationSettings != null)
            {
                foreach (string k in applicationSettings.Keys)
                {
                    LogInfo(string.Format("{0} = {1}", k, applicationSettings[k]));
                }
            }
            LogInfo("----- -----");
        }

        /*
        public void LogObjectInformation(object objectToLog)
        {
            throw new NotImplementedException();
        }
         */

        /// <summary>
        /// Logs a message with the debug level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message)
        {
            LogMessage(LoggingLevel.Debug, message);
        }

        /// <summary>
        /// Logs a message with the debug level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        public void LogDebug(string format, params object[] values)
        {
            string message = string.Format(format, values);
            LogDebug(message);
        }

        /// <summary>
        /// Logs a message with the info level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(string message)
        {
            LogMessage(LoggingLevel.Info, message);
        }

        /// <summary>
        /// Logs a message with the info level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        public void LogInfo(string format, params object[] values)
        {
            string message = string.Format(format, values);
            LogInfo(message);
        }

        /// <summary>
        /// Logs a message with the error level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            LogMessage(LoggingLevel.Error, message);
        }

        /// <summary>
        /// Logs a message with the warn level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        public void LogWarn(string format, params object[] values)
        {
            string message = string.Format(format, values);
            LogWarn(message);
        }

        /// <summary>
        /// Logs a message with the warn level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarn(string message)
        {
            LogMessage(LoggingLevel.Warn, message);
        }

        /// <summary>
        /// Logs a message with the error level and input is by using string.format
        /// </summary>
        /// <param name="format">The format which is used as first parameter of string.format()</param>
        /// <param name="values">The values which are used as the second parameter of string.format()</param>
        public void LogError(string format, params object[] values)
        {
            string message = string.Format(format, values);
            LogError(message);
        }

        private void LogMessage(LoggingLevel level, string message)
        {
            if (_log == null)
            {
                return;
            }
            message = ShowStackTrace && _debugIsEnabled ? string.Format("[{0}] {1}", GetCallingMethod(), message) : message;
            switch (level)
            {
                case LoggingLevel.Debug:
                    _log.Debug(message);
                    break;
                case LoggingLevel.Error:
                    _log.Error(message);
                    break;
                case LoggingLevel.Fatal:
                    _log.Fatal(message);
                    break;
                case LoggingLevel.Info:
                    _log.Info(message);
                    break;
                case LoggingLevel.Warn:
                    _log.Warn(message);
                    break;
            }
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();
            if (stackFrames.Length < 4)
            {
                return string.Empty;
            }
            StackFrame trace = stackFrames[3];
            MethodBase mb = trace.GetMethod();
            Type t = mb.DeclaringType;
            return string.Format("{0}.{1}", t.ToString(), mb.Name);
        }

        internal void ReadConfiguration()
        {
            GlobalContext.Properties["LogFileName"] = LogFileName;
            LogFileDatePartCreator creator = new LogFileDatePartCreator();
            GlobalContext.Properties["LogFileDate"] = creator.CreateDatePartForLogFileName();
            string configurationFileName = string.Empty;
            try
            {
                configurationFileName = Assembly.GetExecutingAssembly().FindFileNextToAssembly(Properties.Resources.Log4NetConfigurationFileName);
            }
            catch (FileNotFoundException e)
            {
                return;
            }
            XmlConfigurator.Configure(new FileInfo(configurationFileName));
        }

        #endregion

        #region ILogger Members

        /// <summary>
        /// Logs the exception information which will log at error level and the stacktrace
        /// </summary>
        /// <param name="e">The exception</param>
        public void LogException(Exception e)
        {
            string message = string.Format("{0}\r\n{1}\r\n{2}", e.Message, e.Source, e.StackTrace);
            LogError(message);
        }

        #endregion

        #region ILogger Members

        public string FullLogFileName
        {
            get
            {
                return string.Format("{0}_{1}_log.xml", GlobalContext.Properties["LogFileName"], GlobalContext.Properties["LogFileDate"]);
            }
        }

        #endregion
    }
}
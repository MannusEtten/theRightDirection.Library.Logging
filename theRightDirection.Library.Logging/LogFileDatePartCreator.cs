using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace theRightDirection.Library.Logging
{
    /// <summary>
    /// class used to create the filename for the logging-file
    /// </summary>
    internal class LogFileDatePartCreator
    {
		#region Methods (2) 

		// Public Methods (1) 

        /// <summary>
        /// Creates a part of the logfilename
        /// </summary>
        /// <returns>date in format of {day}{month}{year}</returns>
        public string CreateDatePartForLogFileName()
        {
            DateTime now = DateTime.Now;
            string day = FormatNumber(now.Day);
            string month = FormatNumber(now.Month);
            return string.Format("{0}{1}{2}", day, month, now.Year);
        }
		// Private Methods (1) 

        internal string FormatNumber(int number)
        {
            string format = number.ToString();
            if (format.Length == 1)
            {
                return "0" + format;
            }
            return format;
        }

		#endregion Methods 
    }
}
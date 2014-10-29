using System;
using theRightDirection.Library.Logging;

namespace theRightDirection.Library
{
    /// <summary>
    /// exception which is used by the framework
    /// </summary>
    public class LibraryException : Exception
    {
		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryException"/> class. Creating an new instance
        /// will also log the message to the logger
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public LibraryException(string message) : base(message)
        {
            Console.WriteLine(String.Format("error occured: {0}", message));
            Logger.GetLogger().LogException(this);
        }

		#endregion Constructors 
    }
}

using System;
using theRightDirection.Library.Logging;
namespace theRightDirection.Library
{
	/// <summary>
	/// Base object for the framework which initiliaze a logger. Adds a method which can log all the values
	/// of all properties and has an overriden ToString(). This method shows all values of all properties.
	/// </summary>
	public abstract class LibraryBaseObject
	{
		#region Fields (1) 

		/// <summary>
		/// the logger object
		/// </summary>
		protected ILogger _logger = null;

		#endregion Fields 

		public LibraryBaseObject()
		{
			_logger = Logger.GetLogger();
		}

		#region Methods (5) 

		// Public Methods (5) 

		/*
		/// <summary>
		/// Logs the object information in a standard text-format. Suitable for the default logger.
		/// </summary>
		public void LogObjectInformation()
		{
			string result = string.Format("{0}\r\n{1}", this.GetType().Name, this.ToString("Text"));
			if(logger != null ) logger.LogDebug(result);
		}

		/// <summary>
		/// Logs the object information in a given format.
		/// </summary>
		/// <param name="format">The format which excepts on this moment only "Text"</param>
		public void LogObjectInformation(string format)
		{
			string result = string.Format("{0}\r\n{1}", this.GetType().Name, this.ToString(format));
			if (logger != null) logger.LogDebug(result);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance. This string contains all values
		/// of all properties in a given format.
		/// </summary>
		/// <example>
		/// Assume that type of variable "exampleClass" inherits from EnsoObjectWithLogging
		/// <c>string exampleString = string.format("{0:Text}", exampleClass);</c>
		/// </example>
		/// <param name="format">The format which excepts on this moment only "Text"</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public string ToString(string format)
		{
			return ToString(format, null);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance. This string contains all values
		/// of all properties in a given format and with a given format provider.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			PropertiesReader reader = new PropertiesReader(this);
			reader.ReadProperties();
			switch(format)
			{
				case "Text": string result = string.Format("{0:Text}",reader);
					if (result.Length == 0) result = this.GetType().Name;
					return result;
					break;
				default: return string.Empty;
					break;
			}
		}
		 */

		#endregion Methods
	}
}
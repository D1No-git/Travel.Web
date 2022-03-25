using System;
using System.Globalization;

namespace Travel.Application.Common.Exceptions
{
    /// <summary>
    /// The preceding code is for an exception that we are going to use in our email service.
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, params object[] args)
          : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
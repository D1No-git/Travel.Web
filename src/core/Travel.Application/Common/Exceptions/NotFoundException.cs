using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.Common.Exceptions
{
    /// <summary>
    /// The following code is an overloading method for throwing NotFoundException with the meaning inside the commands.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
          : base() { }

        public NotFoundException(string message)
          : base(message) { }

        public NotFoundException(string message, Exception innerException)
          : base(message, innerException) { }

        public NotFoundException(string name, object key)
          : base($"Entity \"{name}\" ({key}) was not found.") { }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GunneryCalculator.Common.Exceptions
{
    public class GunneryException : Exception
    {
        public GunneryException()
        {
        }

        public GunneryException(string message) : base(message)
        {
        }

        public GunneryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GunneryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

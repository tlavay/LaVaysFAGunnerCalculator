using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GunneryCalculator.Common.Exceptions
{
    public sealed class TFTException : GunneryException
    {
        public TFTException()
        {
        }

        public TFTException(string message) : base(message)
        {
        }

        public TFTException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

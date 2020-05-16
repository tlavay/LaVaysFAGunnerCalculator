using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GunneryCalculatorCommon.Exceptions
{
    public class SafetyException : GunneryException
    {
        public SafetyException()
        {
        }

        public SafetyException(string message) : base(message)
        {
        }

        public SafetyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

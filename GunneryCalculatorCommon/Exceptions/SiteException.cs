using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GunneryCalculatorCommon.Exceptions
{
    public sealed class SiteException : GunneryException
    {
        public SiteException()
        {
        }

        public SiteException(string message) : base(message)
        {
        }

        public SiteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

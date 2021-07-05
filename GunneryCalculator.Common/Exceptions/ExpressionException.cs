﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GunneryCalculator.Common.Exceptions
{
    public sealed class ExpressionException : GunneryException
    {
        public ExpressionException()
        {
        }

        public ExpressionException(string message) : base(message)
        {
        }

        public ExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace CS_ClassLibrary.LinearAlgebra
{
    [Serializable]
    internal class NoInverseException : Exception
    {
        public NoInverseException()
        {
        }

        public NoInverseException(string message) : base(message)
        {
        }

        public NoInverseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoInverseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace NeilvynSampleBlueprint.Mobile.Common.Exceptions
{
    [Serializable]
    public class NoInternetConnectivityException : Exception
    {
        public NoInternetConnectivityException()
               : this("Not Connected")
        { }

        public NoInternetConnectivityException(string message)
            : base(message)
        { }

        public NoInternetConnectivityException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected NoInternetConnectivityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

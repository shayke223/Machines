using System;

namespace WpfApp1.Exceptions
{
    internal class CustomClientException : Exception
    {

        public CustomClientException()
            : base() { }


        public CustomClientException(string message)
            : base(message) { }

        public CustomClientException(string message, Exception innerException)
            : base(message, innerException) { }

        public string ErrorCode { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CaptainHook
{
    public class CaptainHookException : Exception
    {
        public CaptainHookException()
        {
        }

        public CaptainHookException(string message) : base(message)
        {
        }

        public CaptainHookException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CaptainHookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

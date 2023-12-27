using System.Runtime.Serialization;

namespace Speridian.MMS.Exceptions
{
    public class MMSExceptions : ApplicationException
    {
        public MMSExceptions()
        {
        }

        public MMSExceptions(string? message) : base(message)
        {
        }

        public MMSExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MMSExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class InvalidAudit : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidAudit()
        { }

        public InvalidAudit(string message) : base(message)
        { }

        public InvalidAudit(string message, Exception inner) : base(message, inner)
        { }

        protected InvalidAudit(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        { }
    }
}
using System.Runtime.Serialization;

namespace Mc2.CrudTest.Presentation.Shared.Facade
{
    [Serializable]
    internal class QueryDidNotHaveResultException : Exception
    {
        public QueryDidNotHaveResultException()
        {
        }

        public QueryDidNotHaveResultException(string? message) : base(message)
        {
        }

        public QueryDidNotHaveResultException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected QueryDidNotHaveResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
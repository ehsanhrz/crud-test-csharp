namespace Mc2.CrudTest.Presentation.Shared.Exceptions
{
    public class ServiceNotFoundeException : Exception
    {
        public override string Message => SharedExceptions.ServiceNotFound;
    }
}
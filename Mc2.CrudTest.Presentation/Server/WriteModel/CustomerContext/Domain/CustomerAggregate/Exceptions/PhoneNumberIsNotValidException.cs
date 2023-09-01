using Mc2.CrudTest.Presentation.Shared.Domain;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.Exceptions
{
    public class PhoneNumberIsNotValidException : DomainException
    {
        public override string Message => "the phone number is not valid";
    }
}
using Mc2.CrudTest.Presentation.Shared.Domain;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.Exceptions
{
    public class UserIsNotUniqueExceotion : DomainException
    {
        public override string Message => "this user has registred before";
    }
}

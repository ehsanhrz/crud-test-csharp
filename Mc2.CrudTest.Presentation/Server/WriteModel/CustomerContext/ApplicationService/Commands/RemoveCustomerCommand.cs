using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands
{
    public class RemoveCustomerCommand : Command
    {
        public Guid Id { get; set; }
    }
}

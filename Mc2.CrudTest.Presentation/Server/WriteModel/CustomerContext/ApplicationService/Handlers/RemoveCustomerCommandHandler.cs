using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Handlers
{
    public class RemoveCustomerCommandHandler : ICommandHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        public RemoveCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void Handle(RemoveCustomerCommand command)
        {
            customerRepository.RemoveCustomer(command.Id);
        }
    }
}

using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Handlers
{
    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerValidator customerValidator;
        public AddCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerValidator customerValidator)
        {
            this.customerRepository = customerRepository;
            this.customerValidator = customerValidator;
        }
        public void Handle(AddCustomerCommand command)
        {
            var newCustomer = new Customer(command.FirstName, command.LastName, command.DateOfBirth,
                command.PhoneNumber, command.Email, command.BanckAccountNumber,customerValidator, customerRepository);

            customerRepository.AddCustomer(newCustomer);
        }
    }
}

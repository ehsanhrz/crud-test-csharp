using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.Exceptions;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Handlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerValidator validator;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerValidator validator)
        {
            this.customerRepository = customerRepository;
            this.validator = validator;
        }
        public void Handle(UpdateCustomerCommand command)
        {
            Customer customer = customerRepository.GetCustomerById(command.Id);

            UpdateCustomerPhoneNumber(command, customer);

            UpdateCustomerIdentityInfo(command, customer);

            if (!string.IsNullOrEmpty(command.Email))
                customer.Email = command.Email;

            if (!string.IsNullOrEmpty(command.BankAccountNumber))
                customer.BankAccountNumber = command.BankAccountNumber;
        }

        private void UpdateCustomerIdentityInfo(UpdateCustomerCommand command, Customer customer)
        {
            if (!string.IsNullOrEmpty(command.FirstName))
                customer.FirstName = command.FirstName;

            if (!string.IsNullOrEmpty(command.LastName))
                customer.LastName = command.LastName;

            if (!string.IsNullOrEmpty(command.DateOfBirth))
                customer.DateOfBirth = Convert.ToDateTime(command.DateOfBirth);

            if (!string.IsNullOrEmpty(command.FirstName) || !string.IsNullOrEmpty(command.LastName) || !string.IsNullOrEmpty(command.DateOfBirth))
                if (customerRepository.IsUserUnique(customer.FirstName, customer.LastName, customer.DateOfBirth))
                    throw new UserIsNotUniqueExceotion();
        }

        private void UpdateCustomerPhoneNumber(UpdateCustomerCommand command, Customer customer)
        {
            if (!string.IsNullOrEmpty(command.PhoneNumber))
            {
                customer.PhoneNumber = command.PhoneNumber;
                if (!validator.IsPhoneNumberValid(customer.PhoneNumber))
                    throw new PhoneNumberIsNotValidException();
            }
        }
    }
}

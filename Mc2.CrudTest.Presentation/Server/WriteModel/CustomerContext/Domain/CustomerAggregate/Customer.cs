using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.Exceptions;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Domain.Abstraction;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate
{
    public class Customer : EntityBase, IAggregateRoot<Customer>
    {
        private readonly ICustomerValidator validator;
        private readonly ICustomerRepository repository;

        public Customer(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email,
            string bankAccountNumber, ICustomerValidator validator, ICustomerRepository repository)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
            this.validator = validator;
            this.repository = repository;
            ValidatePhoneNumber();
            ValidateUserUniqness();
        }

        protected Customer()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public void ValidatePhoneNumber()
        {
            if (!validator.IsPhoneNumberValid(PhoneNumber))
                throw new PhoneNumberIsNotValidException();
        }

        public void ValidateUserUniqness()
        {
            if (repository.IsUserUnique(FirstName, LastName, DateOfBirth))
                throw new UserIsNotUniqueExceotion();
        }

    }
}
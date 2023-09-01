using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands
{
    public class UpdateCustomerCommand : Command
    {

        public UpdateCustomerCommand()
        {
            
        }
        public UpdateCustomerCommand(Guid id, string firstName, string lastName, string dateOfbirth, 
            string phoneNumber, string email, string banckAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfbirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = banckAccountNumber;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
    }
}

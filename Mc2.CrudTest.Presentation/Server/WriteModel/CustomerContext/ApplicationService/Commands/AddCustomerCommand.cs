using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using System.Net.Http.Headers;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands
{
    public class AddCustomerCommand : Command
    {
        public AddCustomerCommand(string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber, string banckAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BanckAccountNumber = banckAccountNumber;
        }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string BanckAccountNumber { get; set; } = string.Empty;
    }
}

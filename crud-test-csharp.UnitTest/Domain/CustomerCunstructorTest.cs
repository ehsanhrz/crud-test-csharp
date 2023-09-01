using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;

namespace crud_test_csharp.UnitTest.Domain
{
    public class CustomerCunstructorTest
    {
        private readonly Mock<ICustomerValidator> validatorMock;
        private readonly Mock<ICustomerRepository> repositoryMock;
        public CustomerCunstructorTest()
        {
            validatorMock = new Mock<ICustomerValidator>();
            repositoryMock = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void TestCunstomerCunstructor()
        {
            var firstName = "Ehsan";
            var lastName = "HeidarZadeh";
            var dateOfBirth = DateTime.Today;
            var phoneNumber = "+989919697506";
            var email = "ehsanheidarzadeh959@gmail.com";
            var bankAccountNumber = "10.546521.10";

            validatorMock.Setup(obj => obj.IsPhoneNumberValid(phoneNumber)).Returns(true);
            repositoryMock.Setup(obj => obj.IsUserUnique(firstName, lastName, dateOfBirth)).Returns(false);

            var newCustomer = new Customer(firstName, lastName, dateOfBirth, phoneNumber,
                email, bankAccountNumber, validatorMock.Object, repositoryMock.Object);
            AssertTestCustomerCunstructor(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber, newCustomer);
        }

        private static void AssertTestCustomerCunstructor(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber, Customer newCustomer)
        {
            Assert.NotNull(newCustomer);
            Assert.Equal(firstName, newCustomer.FirstName);
            Assert.Equal(lastName, newCustomer.LastName);
            Assert.Equal(dateOfBirth, newCustomer.DateOfBirth);
            Assert.Equal(phoneNumber, newCustomer.PhoneNumber);
            Assert.Equal(email, newCustomer.Email);
            Assert.Equal(bankAccountNumber, newCustomer.BankAccountNumber);
        }
    }
}
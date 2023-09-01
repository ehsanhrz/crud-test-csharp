using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories;
using Microsoft.OpenApi.Any;

namespace crud_test_csharp.IntgrationTest.RepositoriesTest
{
    public class CustomerRepositoryTest : CustomerRepositoryTestFixture
    {
        private readonly CustomerRepository customerRepository;

        public CustomerRepositoryTest()
        {
            customerRepository = CreateCustomerRepository();
        }

        [Fact]
        public void TestCustomerInsert()
        {
            Customer customer = CreateCustomerForTest();

            Customer? result = InsertCustomerToDataBase(customer);

            AssertCustomerInsertTest(customer, result);
        }

        private Customer? InsertCustomerToDataBase(Customer customer)
        {
            customerRepository.AddCustomer(customer);
            dbContext.SaveChanges();

            var result = dbContext.Set<Customer>().SingleOrDefault(r => r.Id == customer.Id);
            return result;
        }

        private Customer CreateCustomerForTest()
        {
            var now = DateTime.Now;
            customerValidatorMock.Setup(s => s.IsPhoneNumberValid("+989919697506")).Returns(true);
            customerRepositoryMock.Setup(s => s.IsUserUnique("ehsan", "heidarzadeh", now)).Returns(false);
            var customer = new Customer("ehsan", "heidarzadeh", now, "+989919697506",
                "ehsanheidarzadeh@gmail.com", "10.10589865.1", customerValidatorMock.Object,customerRepositoryMock.Object);
            return customer;
        }

        private static void AssertCustomerInsertTest(Customer customer, Customer? result)
        {
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.Email, result.Email);
        }

        [Fact]
        public void TestCustomerDelete()
        {
            Customer result = InsertDummyCustomerToDataBasaeForTest();

            Customer? operationResult = RemoveCustomerFromDatabase(result);

            Assert.Null(operationResult);
        }

        private Customer InsertDummyCustomerToDataBasaeForTest()
        {
            var customer = CreateCustomerForTest();
            Customer result = InsertCustomerToDataBase(customer) ?? throw new Exception();
            AssertCustomerInsertTest(customer, result);
            return result;
        }

        private Customer? RemoveCustomerFromDatabase(Customer result)
        {
            customerRepository.RemoveCustomer(result.Id);
            dbContext.SaveChanges();
            var operationResult = dbContext.Set<Customer>().SingleOrDefault(r => r.Id == result.Id);
            return operationResult;
        }

        [Fact]
        public void TestGetCustomerById()
        {
            Customer customer = InsertDummyCustomerToDataBasaeForTest();

            var result = customerRepository.GetCustomerById(customer.Id);

            AssertGetCustomerByIdTest(customer, result);
        }

        private static void AssertGetCustomerByIdTest(Customer customer, Customer result)
        {
            Assert.Equal(result.Id, customer.Id);
            Assert.Equal(result.FirstName, customer.FirstName);
            Assert.Equal(result.Email, customer.Email);
        }

        [Fact]
        public void TestGetCustomerByEmail()
        {
            Customer customer = InsertDummyCustomerToDataBasaeForTest();

            var result = customerRepository.GetCustomerByEmail(customer.Email);

            AssertGetCustomerByEmailTest(customer, result);
        }

        private static void AssertGetCustomerByEmailTest(Customer customer, Customer result)
        {
            Assert.Equal(result.Id, customer.Id);
            Assert.Equal(result.FirstName, customer.FirstName);
            Assert.Equal(result.Email, customer.Email);
        }

        [Fact]
        public void TestIsUniqueQuery()
        {
            Customer customer = InsertDummyCustomerToDataBasaeForTest();
            var result = customerRepository.IsUserUnique(customer.FirstName, customer.LastName, customer.DateOfBirth);
            Assert.True(result);
        }
    }
}
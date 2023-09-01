using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace crud_test_csharp.IntgrationTest.RepositoriesTest
{
    public class CustomerRepositoryTestFixture
    {
        protected AppDbContext dbContext;
        protected Mock<ICustomerValidator> customerValidatorMock;
        protected Mock<ICustomerRepository> customerRepositoryMock;
        protected CustomerRepositoryTestFixture()
        {
            var options = CreateNewContextOptions();
            customerValidatorMock = new Mock<ICustomerValidator>();
            customerRepositoryMock = new Mock<ICustomerRepository>();
            dbContext = new AppDbContext(options);
        }

        protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("sql")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository(dbContext);
        }
    }
}
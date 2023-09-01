using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddCustomer(Customer customer)
        {
            context.Set<Customer>().Add(customer);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return context.Set<Customer>().FirstOrDefault(r => r.Email == email) ?? throw new CustomerNotFoundException();
        }

        public Customer GetCustomerById(Guid id)
        {
            return context.Set<Customer>().FirstOrDefault(r => r.Id == id) ?? throw new CustomerNotFoundException();
        }

        public bool IsUserUnique(string firstName, string lastName, DateTime dateOfBirth)
        {
            return context.Set<Customer>().Any(r => r.FirstName == firstName && r.LastName == lastName && r.DateOfBirth == dateOfBirth);
        }

        public void RemoveCustomer(Guid id)
        {
            var result = context.Set<Customer>().Where(r => r.Id == id).SingleOrDefault() ?? throw new CustomerNotFoundException();
            context.Set<Customer>().Remove(result);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
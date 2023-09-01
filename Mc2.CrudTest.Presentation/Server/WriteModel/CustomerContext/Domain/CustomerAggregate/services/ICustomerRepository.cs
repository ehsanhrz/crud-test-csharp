namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);

        void RemoveCustomer(Guid id);

        void SaveChanges();

        bool IsUserUnique(string firstName, string lastName, DateTime dateOfBirth);

        Customer GetCustomerById(Guid id);

        Customer GetCustomerByEmail(string email);
    }
}
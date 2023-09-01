namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services
{
    public interface ICustomerValidator
    {
        bool IsPhoneNumberValid(string phoneNumber);
    }
}
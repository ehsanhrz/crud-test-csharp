using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.CustomerServices
{
    public class CustomerValidator : ICustomerValidator
    {
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var testCase = phoneNumberUtil.Parse(phoneNumber, "");
            return phoneNumberUtil.IsValidNumber(testCase);
        }
    }
}

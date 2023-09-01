using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_csharp.UnitTest.Domain
{
    public class CustomerValidatorTest
    {
        private CustomerValidator validator;

        public CustomerValidatorTest()
        {
            validator = new CustomerValidator();
        }

        [Fact]
        public void TestIsPhoneNumberValid()
        {
            var result = validator.IsPhoneNumberValid("+989919697506");
            Assert.True(result);
        }
    }
}

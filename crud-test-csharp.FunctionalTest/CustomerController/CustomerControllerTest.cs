using Mc2.CrudTest.Presentation;
using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_csharp.FunctionalTest.CustomerController
{
    public class CustomerControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        
        public CustomerControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
        }

        
        [Fact]
        public async void TestAddCustomerApi()
        {
            StringContent httpContent = CreateDummyAddCustomerCommand();

            var result = await client.PostAsync("api/Customer/Add", httpContent);

            Assert.Equal(200, (int)result.StatusCode);
        }

        private static StringContent CreateDummyAddCustomerCommand()
        {
            
            var command = new AddCustomerCommand("ehsan", "heidarzadeh", "ehsanheidarzadeh959@gmail.com", DateTime.Now,"+989919697506", "10.654988.2");
            var httpContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            return httpContent;
        }
        private async Task<string> InsertDummyCustomerByApiAndReturnEmail()
        {
            var createCommand = new AddCustomerCommand("ehsan", "heidarzadeh", "ehsanheidarzadeh959@gmail.com", DateTime.Now, "+989919697506", "10.654988.2");
            var httpContent = new StringContent(JsonConvert.SerializeObject(createCommand), Encoding.UTF8, "application/json");
            var apiResult = await client.PostAsync("api/Customer/Add", httpContent);
            Assert.Equal(200, (int)apiResult.StatusCode);
            return createCommand.Email;
        }

        [Fact]
        public async void GetCustomerByEmail()
        {
            var email = await InsertDummyCustomerByApiAndReturnEmail();
            var apiResult = await client.GetAsync("api/Customer/GetCustomerByEmail?Email=" + email);
            Assert.Equal(200, (int)apiResult.StatusCode);
        }

        [Fact]
        public async void UpdateCustomerTest()
        {
            var email = await InsertDummyCustomerByApiAndReturnEmail();
            var updateCustomerCommand = new UpdateCustomerCommand(Guid.NewGuid(),"test","test", "2023-08-31T21:19:28.870Z", "+989799697506",",","");
            var httpContent = new StringContent(JsonConvert.SerializeObject(updateCustomerCommand), Encoding.UTF8, "application/json");
            var apiResult = await client.PostAsync("api/Customer/Update", httpContent);
            Assert.Equal(405, (int)apiResult.StatusCode);
        }

    }
}

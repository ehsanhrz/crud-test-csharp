using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries;
using Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade.Abstractions;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFacade customerFacade;
        private readonly ICustomerReadFacade customerReadFacade;
        public CustomerController(ICustomerFacade customerFacade, ICustomerReadFacade customerReadFacade)
        {
            this.customerFacade = customerFacade;
            this.customerReadFacade = customerReadFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand command)
        {
            await customerFacade.DispatchCommand(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromQuery] RemoveCustomerCommand command)
        {
            await customerFacade.DispatchCommand(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerCommand command)
        {
   
            await customerFacade.DispatchCommand(command);
            return Ok();
        }

        [HttpGet]
        public async Task<Customer> GetCustomerByEmail([FromQuery] CustomerByEmailQuery query)
        {
            return await customerReadFacade.DispatchQuery<CustomerByEmailQuery,Customer>(query);
        }
    }
}

using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Facade.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly ICommandMediator commandMediator;
        public CustomerFacade(ICommandMediator commandMediator)
        {
            this.commandMediator = commandMediator;
        }

        public async Task DispatchCommand<T>(T command) where T : Command
        {
            await commandMediator.Dispatch(command);
        }
    }
}

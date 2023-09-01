using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade.Abstractions
{
    public interface ICustomerFacade
    {
        Task DispatchCommand<T>(T command) where T : Command;
    }
}

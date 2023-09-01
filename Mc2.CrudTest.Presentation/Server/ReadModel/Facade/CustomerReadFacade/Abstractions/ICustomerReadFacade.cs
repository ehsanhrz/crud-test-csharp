using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade.Abstractions
{
    public interface ICustomerReadFacade
    {
        Task<TOut> DispatchQuery<T,TOut>(T query) where T : Query;
    }
}

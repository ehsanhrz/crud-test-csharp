using Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Facade.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade
{
    public class CustomerReadFacade : ICustomerReadFacade
    {
        private readonly IQueryMediator queryMediator;
        public CustomerReadFacade(IQueryMediator queryMediator)
        {
            this.queryMediator = queryMediator;
        }
        public async Task<TOut> DispatchQuery<T, TOut>(T query) where T : Query
        {
            return await queryMediator.Dispatch<T, TOut>(query);
        }
    }
}

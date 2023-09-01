using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DependencyInjection.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Facade.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Facade
{
    public class QueryMediator : IQueryMediator
    {
        private readonly IDIContainer dIContainer;

        public QueryMediator(IDIContainer dIContainer)
        {
            this.dIContainer = dIContainer;
        }

        public async Task<TOut> Dispatch<T, TOut>(T query) where T : Query
        {
            var result = await Task.Run(() =>
            {
                var queryHandler = (IQueryHandler<T, TOut>)ResolveHandler<T, TOut>(query);
                return queryHandler.Handle(query);

            });
            return result ?? throw new QueryDidNotHaveResultException();
        }

        private object ResolveHandler<T, TOut>(T query) where T : Query
        {
            return dIContainer.Resolve<IQueryHandler<T, TOut>>();
        }
    }
}
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Facade.Abstractions
{
    public interface IQueryMediator
    {
        Task<TOut> Dispatch<T,TOut>(T query) where T : Query;
    }
}
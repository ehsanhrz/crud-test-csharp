namespace Mc2.CrudTest.Presentation.Shared.Application.Abstractions
{
    public interface IQueryHandler<T,TOut> where T : Query 
    {
        TOut Handle(T query);
    }
}
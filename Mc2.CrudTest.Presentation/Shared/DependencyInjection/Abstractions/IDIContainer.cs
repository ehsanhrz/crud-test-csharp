namespace Mc2.CrudTest.Presentation.Shared.DependencyInjection.Abstractions
{
    public interface IDIContainer
    {
        object Resolve<T>();
    }
}
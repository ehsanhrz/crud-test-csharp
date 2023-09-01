using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Facade.Abstractions
{
    public interface ICommandMediator
    {
        Task Dispatch<T>(T command) where T : Command;
    }
}
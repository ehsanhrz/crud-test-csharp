using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Application.Abstractions
{
    public interface ICommandHandler<T> where T : Command
    {
        void Handle(T command);
    }
}
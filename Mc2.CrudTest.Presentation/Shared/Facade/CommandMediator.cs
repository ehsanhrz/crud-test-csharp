using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DependencyInjection.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Facade.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Facade
{
    public class CommandMediator : ICommandMediator
    {
        private readonly IDIContainer dIContainer;
        private readonly IDBContext dBContext;

        public CommandMediator(IDIContainer dIContainer, IDBContext dBContext)
        {
            this.dIContainer = dIContainer;
            this.dBContext = dBContext;
        }

        public async Task Dispatch<T>(T command) where T : Command
        {
            await Task.Run(() =>
            {
                var commandHandler = (ICommandHandler<T>)ResolveHandler(command);
                var TransActionalHandler = new TransActionalHandler<T>(dBContext, commandHandler, command);
                TransActionalHandler.Execute();
            });

        }

        private object ResolveHandler<T>(T command) where T : Command
        {
            return dIContainer.Resolve<ICommandHandler<T>>();
        }
    }
}
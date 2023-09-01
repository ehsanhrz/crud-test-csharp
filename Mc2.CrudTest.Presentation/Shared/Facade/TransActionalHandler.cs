using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Facade
{
    public class TransActionalHandler<T> where T : Command
    {
        private readonly IDBContext dBContext;
        private readonly ICommandHandler<T> commandHandler;
        private readonly T command;

        public TransActionalHandler(IDBContext dBContext, ICommandHandler<T> commandHandler, T command)
        {
            this.dBContext = dBContext;
            this.commandHandler = commandHandler;
            this.command = command;
        }

        public void Execute()
        {
            try
            {
                commandHandler.Handle(command);
                dBContext.Commit();
            }
            catch
            {
                dBContext.RollBack();
                throw;
            }
        }
    }
}
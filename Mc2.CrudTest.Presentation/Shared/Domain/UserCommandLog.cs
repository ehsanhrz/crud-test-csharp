using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Shared.Domain
{
    public class UserCommandLog
    {
        public UserCommandLog(Command command)
        {
            TimeStamp = DateTime.Now;
            this.command = command;
        }

        protected UserCommandLog()
        { }

        public DateTime TimeStamp { get; set; }

        public Command command { get; set; }
    }
}
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries
{
    public class CustomerByIdQuery : Query
    {
        public Guid Id { get; set; }
    }
}

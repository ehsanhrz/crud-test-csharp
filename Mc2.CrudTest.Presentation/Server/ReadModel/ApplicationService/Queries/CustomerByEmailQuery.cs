using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries
{
    public class CustomerByEmailQuery : Query
    {
         
        public string Email { get; set; } = string.Empty;
    }
}

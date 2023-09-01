using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.QueryHandler
{
    public class CustomerByEmailQueryHandler : IQueryHandler<CustomerByEmailQuery, Customer>
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerByEmailQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Customer Handle(CustomerByEmailQuery query)
        {
            return customerRepository.GetCustomerByEmail(query.Email);
        }
    }
}

using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;

namespace Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.QueryHandler
{
    public class CustomerByIdQueryHandler : IQueryHandler<CustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Handle(CustomerByIdQuery query)
        {
            return customerRepository.GetCustomerById(query.Id);
        }
    }
}

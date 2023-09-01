using Mc2.CrudTest.Presentation.Shared.DependencyInjection.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Exceptions;

namespace Mc2.CrudTest.Presentation.Shared.DependencyInjection
{
    public class DIContainer : IDIContainer
    {
        private readonly IServiceProvider serviceProvider;

        public DIContainer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object Resolve<T>()
        {
            return serviceProvider.GetService(typeof(T)) ?? throw new ServiceNotFoundeException();
        }
    }
}
using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kitchen.Context
{
    /// <summary>
    /// Методы расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceExtensionsContext
    {
        /// <summary>
        /// Регистрирует все что связано с контекстом
        /// </summary>
        /// <param name="service"></param>
        public static void RegistrationContext(this IServiceCollection service)
        {
            service.TryAddScoped<IKitchenContext>(provider => provider.GetRequiredService<KitchenContext>());
            service.TryAddScoped<IDbRead>(provider => provider.GetRequiredService<KitchenContext>());
            service.TryAddScoped<IDbWriter>(provider => provider.GetRequiredService<KitchenContext>());
            service.TryAddScoped<IUnitOfWork>(provider => provider.GetRequiredService<KitchenContext>());
        }
    }
}

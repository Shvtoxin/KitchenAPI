using Kitchen.General;
using Kitchen.Services.Anchors;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Services
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceExtensionsService
    {
        /// <summary>
        /// Регистрация всех сервисов
        /// </summary>
        public static void RegistrationService(this IServiceCollection service)
        {
            service.RegistrationOnInterface<IServiceAnchor>(ServiceLifetime.Scoped);
        }
    }
}

using Kitchen.API.Mappers;
using Kitchen.Common.Entity;
using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context;
using Kitchen.Repositories;
using Kitchen.Services;
using Kitchen.Services.Mappers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Kitchen.API.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Регистрирует все сервисы, репозитории и все что нужно для контекста
        /// </summary>
        public static void RegistrationSRC(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IDbWriterContext, DbWriterContext>();
            services.RegistrationService();
            services.RegistrationRepository();
            services.RegistrationContext();
            services.AddAutoMapper(typeof(APIMapper), typeof(ServiceMapper));
        }

        /// <summary>
        /// Включает фильтры и ставит шрифт на перечесления
        /// </summary>
        /// <param name="services"></param>
        public static void RegistrationControllers(this IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                x.Filters.Add<KitchenExceptionFilter>();
            })
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        CamelCaseText = false
                    });
                })
                .AddControllersAsServices();
        }

        /// <summary>
        /// Настройки свагера
        /// </summary>
        public static void RegistrationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Cuisine", new OpenApiInfo { Title = "Кухни", Version = "v1" });
                c.SwaggerDoc("Post", new OpenApiInfo { Title = "Должности", Version = "v1" });
                c.SwaggerDoc("Stimulation", new OpenApiInfo { Title = "Бонусы", Version = "v1" });
                c.SwaggerDoc("TurnOut", new OpenApiInfo { Title = "Явки", Version = "v1" });
                c.SwaggerDoc("Staff", new OpenApiInfo { Title = "Персонал", Version = "v1" });
                c.SwaggerDoc("TypeOfTurnout", new OpenApiInfo { Title = "Типы явок", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "Kitchen.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        /// <summary>
        /// Настройки свагера
        /// </summary>
        public static void CustomizeSwaggerUI(this WebApplication web)
        {
            web.UseSwagger();
            web.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Cuisine/swagger.json", "Кухни");
                x.SwaggerEndpoint("Post/swagger.json", "Должности");
                x.SwaggerEndpoint("Stimulation/swagger.json", "Бонусы");
                x.SwaggerEndpoint("TurnOut/swagger.json", "Явки");
                x.SwaggerEndpoint("Staff/swagger.json", "Работники");
                x.SwaggerEndpoint("TypeOfTurnout/swagger.json", "Типы явок");
            });
        }
    }
}

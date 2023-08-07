namespace AirsoftWebStore.Web.Infrastructure.Extensions
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.Infrastructure.Middlewares;
    using static Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = serviceType.Assembly;

            if (serviceAssembly == null)
            {
                throw new Exception("Invalid service type provided!");
            }

            Type[] implementationServiceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (var implServiceType in implementationServiceTypes)
            {
                Type? interfaceType = implServiceType.GetInterface($"I{implServiceType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {implServiceType.Name}");
                }

                services.AddScoped(interfaceType, implServiceType);
            }
        }

        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OnlineUsersMiddleware>();
        }
    }
}
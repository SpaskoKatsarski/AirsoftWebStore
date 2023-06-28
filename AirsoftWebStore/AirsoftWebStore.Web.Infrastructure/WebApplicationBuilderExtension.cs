namespace AirsoftWebStore.Web.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

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
    }
}
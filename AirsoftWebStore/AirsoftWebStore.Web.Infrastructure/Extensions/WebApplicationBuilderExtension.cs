namespace AirsoftWebStore.Web.Infrastructure.Extensions
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using AirsoftWebStore.Data.Models;
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

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder builder, string email)
        {
            using IServiceScope scopedServices = builder.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return builder;
        }

        public static IApplicationBuilder SeedModerator(this IApplicationBuilder builder, string email)
        {
            using IServiceScope scopedServices = builder.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(ModeratorRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(ModeratorRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, ModeratorRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return builder;
        }
    }
}
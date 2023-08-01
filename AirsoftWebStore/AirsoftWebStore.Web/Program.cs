using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using AirsoftWebStore.Data.Models;
using AirsoftWebStore.Data;
using AirsoftWebStore.Web.Infrastructure.Extensions;
using AirsoftWebStore.Services.Contracts;
using AirsoftWebStore.Web.Infrastructure.ModelBinders;

using static AirsoftWebStore.Common.GeneralApplicationConstants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AirsoftStoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    // In the future this may be moved from here.
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AirsoftStoreDbContext>();

builder.Services.AddApplicationServices(typeof(IGunService));

builder.Services
    .AddControllersWithViews()
    .AddMvcOptions(options => 
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    //app.UseDeveloperExceptionPage();
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
}
else
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator(AdminEmail);

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();

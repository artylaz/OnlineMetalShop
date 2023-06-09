using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineStore.Application;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Interfaces;
using OnlineStore.Persistence;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddAutoMapper(conf =>
{
    conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    conf.AddProfile(new AssemblyMappingProfile(typeof(IOnlineStoreDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

builder.Services.AddControllersWithViews();

var enCulture = new CultureInfo("en-US");
CultureInfo.CurrentCulture = enCulture;
CultureInfo.CurrentUICulture = enCulture;
CultureInfo.DefaultThreadCurrentCulture = enCulture;
CultureInfo.DefaultThreadCurrentUICulture = enCulture;

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

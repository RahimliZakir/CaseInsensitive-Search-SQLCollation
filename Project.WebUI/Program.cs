using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.DataContexts;
using Project.WebUI.Models.Initializers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration conf = builder.Configuration;

IServiceCollection services = builder.Services;
services.AddControllersWithViews();

services.AddDbContext<ProjectDbContext>(cfg =>
{
    //cfg.UseInMemoryDatabase("TempDB");

    cfg.UseSqlServer(conf.GetConnectionString("cString"));
});

WebApplication app = builder.Build();
IWebHostEnvironment env = builder.Environment;
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseStaticFiles();

await app.Initialize();

app.MapControllerRoute("default", "{controller=People}/{action=Index}/{id?}");

app.Run();

using Project.WebUI.Models.DataContexts;

namespace Project.WebUI.Models.Initializers
{
    public static class DatabaseInitializer
    {
        public static async Task<IApplicationBuilder> Initialize(this IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                ProjectDbContext db = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();

                await PersonInitializer.InitializePeople(db);
            }

            return app;
        }
    }
}

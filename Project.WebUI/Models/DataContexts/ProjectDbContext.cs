using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.Entities;

namespace Project.WebUI.Models.DataContexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // SQL ile qoshulsaq, bu method ile "case-insensitive" ede bilerik.
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        }
    }
}

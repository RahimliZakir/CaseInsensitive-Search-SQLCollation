using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.DataContexts;

namespace Project.WebUI.Models.Initializers
{
    public static class PersonInitializer
    {
        async public static Task InitializePeople(ProjectDbContext db)
        {
            if (!await db.People.AnyAsync())
            {
                await db.People.AddAsync(new()
                {
                    //Id = 1,
                    Name = "Zakir",
                    Surname = "Rahimli",
                    Email = "zrahimli93@gmail.com",
                    Citizenship = "Azerbaijan",
                    Age = 20
                });

                await db.People.AddAsync(new()
                {
                    //Id = 2,
                    Name = "X",
                    Surname = "Y",
                    Email = "xy@gmail.com",
                    Citizenship = "???",
                    Age = 0
                });

                await db.SaveChangesAsync();
            }
        }
    }
}

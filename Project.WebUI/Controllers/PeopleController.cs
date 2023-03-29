using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.DataContexts;
using Project.WebUI.Models.Entities;
using Project.WebUI.Models.ViewModels;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Project.WebUI.Controllers
{
    public class PeopleController : Controller
    {
        readonly ProjectDbContext db;

        public PeopleController(ProjectDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index(PersonViewModel request)
        {
            // Qeyd: "UseCollation" etdikden sonra, enum-lar ile etdiyimiz insensitive kodlar ishlemeyecek...

            IQueryable<Person> query = db.People.AsQueryable();

            // 1. First Way - Case-Insensitive Search (With "Like" method).
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(q => EF.Functions.Like(q.Name, $"{request.Name}%"));

            // 2. Second Way - Case-Insensitive Search (With "StartsWith" method & "StringComparison" enum).
            if (!string.IsNullOrWhiteSpace(request.Surname))
                query = query.Where(q => q.Surname.StartsWith(request.Surname, StringComparison.OrdinalIgnoreCase));

            // 3. Third Way - Case-Insensitive Search (With "IndexOf" method & "StringComparison" enum).
            if (!string.IsNullOrWhiteSpace(request.Email))
                query = query.Where(q => q.Email.IndexOf(request.Email, 0, StringComparison.OrdinalIgnoreCase) != -1);

            // 4. Fourth Way - Case-Insensitive Search (With "UseCollation" method on DbContext file).
            if (!string.IsNullOrWhiteSpace(request.Citizenship))
                //query = query.Where(q => q.Citizenship.StartsWith(request.Citizenship));
                // 5. Bonus (Explicit Collation)
                query = query.Where(q => EF.Functions.Collate(q.Citizenship, "SQL_Latin1_General_CP1_CI_AS").StartsWith(request.Citizenship));

            if (request.Age is not null and > 0)
                query = query.Where(q => q.Age.ToString().StartsWith(request.Age.ToString()));

            PersonViewModel response = new()
            {

                People = await query.ToListAsync()
            };

            return response.People != null ?
                        View(response) :
                        Problem("Entity set 'ProjectDbContext.People'  is null.");
        }
    }
}

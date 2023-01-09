using Project.WebUI.Models.Entities;

namespace Project.WebUI.Models.ViewModels
{
    public class PersonViewModel
    {
        public IEnumerable<Person>? People { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int? Age { get; set; }

        public string? Email { get; set; }

        public string? Citizenship { get; set; }
    }
}

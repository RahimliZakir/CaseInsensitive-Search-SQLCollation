namespace Project.WebUI.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int Age { get; set; }

        public string Email { get; set; } = null!;

        public string Citizenship { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}

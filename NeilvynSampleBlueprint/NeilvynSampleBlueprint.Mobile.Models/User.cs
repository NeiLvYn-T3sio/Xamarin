using SQLite;

namespace NeilvynSampleBlueprint.Mobile.Models
{
    [Table("User")]
    public class User : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Age { get; set; }
        public string AvatarUrl { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsPublic { get; set; }
        public string Name { get; set; } = null!;
        public string StatusMessage { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace DXProject.Models
{
    public interface ITranslation
    {
        string EnglishDetails { get; set; }
        string Example { get; set; }
        string FrenchTranslations { get; set; }
        int Id { get; set; }
        string NameWithType { get; set; }
        string Word { get; set; }
    }

    public class Translation : ITranslation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Word { get; set; }

        public string NameWithType { get; set; }

        public string EnglishDetails { get; set; }

        public string FrenchTranslations { get; set; }

        public string Example { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DXProject.Models
{
    public partial class Word
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Episod { get; set; }
    }
}

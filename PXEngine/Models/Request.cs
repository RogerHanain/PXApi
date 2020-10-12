using System.ComponentModel.DataAnnotations;

namespace DXProject.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public string RequestURL { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Groop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
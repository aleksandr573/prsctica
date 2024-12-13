// Models/prepod.cs
using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Prepod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
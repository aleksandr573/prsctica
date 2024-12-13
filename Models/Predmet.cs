using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Predmet
    {
        [Key]
        public int Id { get; set; }
        public string Nazv { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class TipAud
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kol { get; set; }
    }
}
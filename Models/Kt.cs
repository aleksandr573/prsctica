using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Kt
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPredm { get; set; }

        [ForeignKey(nameof(IdPredm))]
        public Predmet Predmet { get; set; }
    }
}
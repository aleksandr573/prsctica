using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class PredmetPrepod
    {
        [Key]
        public int Id { get; set; }
        public int IdPredm { get; set; }
        public int IdPrepod { get; set; }

        [ForeignKey(nameof(IdPredm))]
        public Predmet Predmet { get; set; }

        [ForeignKey(nameof(IdPrepod))]
        public Prepod Prepod { get; set; }
    }
}

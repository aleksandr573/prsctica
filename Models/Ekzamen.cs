using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Ekzamen
    {
        [Key]
        public int Id { get; set; }
        public int IdPredmetPrepod { get; set; }
        public string Data { get; set; }
        public int IdAud { get; set; }
        public int Mark { get; set; }
        public int IdStudent { get; set; }

        [ForeignKey(nameof(IdPredmetPrepod))]
        public PredmetPrepod PredmetPrepod { get; set; }

        [ForeignKey(nameof(IdAud))]
        public Auditor Auditor { get; set; }

        [ForeignKey(nameof(IdStudent))]
        public Student Student { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class MarkKt
    {
        [Key]
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int Mark { get; set; }
        public string Data { get; set; }
        public int IdKt { get; set; }
        public int IdPredmetPrepod { get; set; }

        [ForeignKey(nameof(IdStudent))]
        public Student Student { get; set; }

        [ForeignKey(nameof(IdKt))]
        public Kt Kt { get; set; }

        [ForeignKey(nameof(IdPredmetPrepod))]
        public PredmetPrepod PredmetPrepod { get; set; }
    }
}
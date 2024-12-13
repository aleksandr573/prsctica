using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Raspisanie
    {
        [Key]
        public int Id { get; set; }
        public int IdPredmetPrepod { get; set; }
        public int IdAud { get; set; }
        public string DenNedeli { get; set; }
        public string NachPar { get; set; }
        public string KonPar { get; set; }
        public int IdGr { get; set; }

        [ForeignKey(nameof(IdPredmetPrepod))]
        public PredmetPrepod PredmetPrepod { get; set; }

        [ForeignKey(nameof(IdAud))]
        public Auditor Auditor { get; set; }

        [ForeignKey(nameof(IdGr))]
        public Groop Groop { get; set; }
    }
}
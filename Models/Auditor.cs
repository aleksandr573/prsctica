using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Auditor
    {
        [Key]
        public int Id { get; set; }
        public int IdTipAud { get; set; }

        [ForeignKey(nameof(IdTipAud))]
        public TipAud TipAud { get; set; }
    }
}
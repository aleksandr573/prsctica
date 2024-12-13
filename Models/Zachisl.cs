using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Zachisl
    {
        [Key]
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public string Data { get; set; }

        [ForeignKey(nameof(IdStudent))]
        public Student Student { get; set; }
    }
}
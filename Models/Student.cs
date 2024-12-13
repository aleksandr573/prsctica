using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Data { get; set; }
        public int IdGr { get; set; }

        [ForeignKey(nameof(IdGr))]
        public Groop Groop { get; set; }
    }
}
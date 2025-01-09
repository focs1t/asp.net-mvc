using System.ComponentModel.DataAnnotations;

namespace rest.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
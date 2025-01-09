using System.ComponentModel.DataAnnotations;

namespace rest.Models
{
    public class Attraction
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Required]
        public bool IsOperational { get; set; }
    }
}
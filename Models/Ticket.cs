using System.ComponentModel.DataAnnotations;

namespace rest.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int? VisitorId { get; set; }

        public Visitor? Visitor { get; set; } // Навигационное свойство

        [Required]
        public int? AttractionId { get; set; }

        public Attraction? Attraction { get; set; } // Навигационное свойство

        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
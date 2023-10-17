using System.ComponentModel.DataAnnotations;

namespace FinTechApplication.Models
{
    public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public AppUser? User { get; set; }
        public string? UserId { get; set; }

        [Required]
        [MaxLength(125, ErrorMessage = "Street name cannot be more than 125")]
        public string? Street { get; set; }

        [Required]
        [MaxLength(125, ErrorMessage = "Street name cannot be more than 125")]
        public string? City { get; set; }

        [Required]
        [MaxLength(125, ErrorMessage = "Street name cannot be more than 125")]
        public string? State { get; set; }
        
    }
}

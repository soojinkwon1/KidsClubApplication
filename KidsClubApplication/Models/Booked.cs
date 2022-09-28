using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class Booked
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? EFullName { get; set; }
        [Required]
        public string? PNumber { get; set; }
        [Required]
        public string? ESubject { get; set; }
        [Required]
        public string? EMessage { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

    }
}
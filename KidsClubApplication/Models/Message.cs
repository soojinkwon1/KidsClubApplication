using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Body { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FullName { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
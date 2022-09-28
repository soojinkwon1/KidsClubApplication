using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class SuMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}

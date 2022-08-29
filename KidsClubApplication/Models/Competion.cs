using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class Competion
    {
        [Key]
        public int CompetionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Descriptino { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class KCActivity
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ActivityDate { get; set; }
        [Required]
        public string MediaType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class NewsLetter
    {
        [Key]
        public int NewsLetterId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}

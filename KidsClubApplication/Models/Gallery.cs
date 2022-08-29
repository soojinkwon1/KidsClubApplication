using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class Gallery
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime EventDateTime { get; set; }

        public List<Participant> Participants { get; set; }
    }
}

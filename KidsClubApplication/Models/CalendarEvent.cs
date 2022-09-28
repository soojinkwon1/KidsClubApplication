using System.ComponentModel.DataAnnotations;

namespace KidsClubApplication.Models
{
    public class CalendarEvent
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}

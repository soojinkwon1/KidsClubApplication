using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KidsClubApplication.Models;

namespace KidsClubApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<KidsClubApplication.Models.Event>? Event { get; set; }
        public DbSet<KidsClubApplication.Models.Gallery>? Gallery { get; set; }
        public DbSet<KidsClubApplication.Models.KCActivity>? KCActivity { get; set; }
        public DbSet<KidsClubApplication.Models.Message>? Message { get; set; }
        public DbSet<KidsClubApplication.Models.SuMessage>? SuMessage { get; set; }
        public DbSet<KidsClubApplication.Models.Booked>? Booked { get; set; }
        /*public DbSet<KidsClubApplication.Models.SchedulerEvent> SchedulerEvents { get; set; }*/
        public DbSet<KidsClubApplication.Models.CalendarEvent> CalendarEvent { get; set; }


    }
}
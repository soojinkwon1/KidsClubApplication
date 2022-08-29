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
        public DbSet<KidsClubApplication.Models.Competion>? Competion { get; set; }
        public DbSet<KidsClubApplication.Models.NewsLetter>? NewsLetter { get; set; }
        public DbSet<KidsClubApplication.Models.Participant>? Participant { get; set; }
    }
}
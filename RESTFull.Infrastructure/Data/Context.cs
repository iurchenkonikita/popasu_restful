using Microsoft.EntityFrameworkCore;
using RESTFull.Domain;

namespace RESTFull.Infrastructure
{
    public class Context : DbContext
    {

        
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}

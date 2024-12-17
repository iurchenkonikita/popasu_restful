using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RESTFull.Domain;

namespace RESTFull.Infrastructure
{
   
    public class Context : DbContext
    {

        
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Trusted_Connection=True;MultipleActiveResultSets=true;"); // Укажите строку подключения
        }

        public void InitializeDatabase(Context context)
        {

            context.Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Conference>()
        //        .HasMany(c => c.participants)
        //        .WithMany(p => p.conferences)
        //        .UsingEntity("ConferenceParticipant",
        //            l => l.HasOne(typeof(Conference)).WithMany().HasForeignKey("ConferenceId").HasPrincipalKey(nameof(Conference.Id)),
        //            r => r.HasOne(typeof(Participant)).WithMany().HasForeignKey("ParticipantId").HasPrincipalKey(nameof(Participant.Id)),
        //            j => j.HasKey("ConferenceId", "ParticipantId"))
        //        ;

        //    ////modelBuilder.Entity<Conference>()
        //    ////    .HasMany(c => c.participants)
        //    ////    .WithMany(p => p.conferences);
        //    //modelBuilder.Entity<Conference>()
        //    //    .HasMany(c => c.sections)
        //    //    .WithOne(s => s.conference);

        //    //modelBuilder.Entity<Report>()
        //    //    .HasMany(r => r.authors)
        //    //    .WithMany(a => a.reports);

        //    //modelBuilder.Entity<Section>()
        //    //    .HasMany(s=>s.reports)
        //    //    .WithOne(s => s.section);

        //    ////modelBuilder.Entity<Participant>()
        //    ////    .HasMany(p => p.conferences)
        //    ////    .WithMany(c => c.participants);
        //    //modelBuilder.Entity<Participant>()
        //    //    .HasMany(p => p.reports)
        //    //    .WithMany(c => c.authors);

        //}

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Participant> Participants { get; set; }



    }
}

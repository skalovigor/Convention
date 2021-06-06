using Convention.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL
{
    public class ConventionDbContext: DbContext
    {

        public ConventionDbContext()
        {
            
        }
        public ConventionDbContext(DbContextOptions<ConventionDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Convention> Conventions { get; set; }
        public DbSet<Domain.Talk> Talks { get; set; }
        public DbSet<Domain.Participant> Participants { get; set; }
        public DbSet<Domain.Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");
            
            modelBuilder.ApplyConfiguration(new ConventionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TalkEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TalkParticipantEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SpeakerEntityConfiguration());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=ConventionDb");
            }
        }
    }
}
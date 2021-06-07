using Convention.DAL.EntityConfigurations;
using Convention.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Convention.DAL
{
    public class ConventionDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public ConventionDbContext()
        {
            
        }
        public ConventionDbContext(DbContextOptions<ConventionDbContext> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Domain.Models.Convention> Conventions { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

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
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class ConventionEntityConfiguration : IEntityTypeConfiguration<Domain.Convention>
    {
        public void Configure(EntityTypeBuilder<Domain.Convention> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.Information).IsRequired();
            builder.Property(e => e.BannerUrl)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.HasMany(m => m.Participants)
                .WithOne(m => m.Convention)
                .HasForeignKey(m => m.ConventionId);

            builder.HasMany(m => m.Talks)
                .WithOne(m => m.Convention)
                .HasForeignKey(m => m.ConventionId);
        }
    }
}
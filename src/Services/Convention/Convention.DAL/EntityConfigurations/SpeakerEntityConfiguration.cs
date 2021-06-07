using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class SpeakerEntityConfiguration: IEntityTypeConfiguration<Domain.Speaker>
    {
        public void Configure(EntityTypeBuilder<Domain.Speaker> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.UserId)
                .HasMaxLength(100).IsRequired();
            builder.Property(e => e.Position)
                .HasMaxLength(100).IsRequired();
            builder.Property(e => e.ProfileUrl)
                .HasMaxLength(255).IsRequired();
            builder.Property(e => e.Approved);

            builder.HasIndex(m => m.UserId)
                .IsUnique();
            
            builder.HasMany(m => m.Talks)
                .WithOne(m => m.Speaker)
                .HasForeignKey(m => m.SpeakerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
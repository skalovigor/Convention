using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class ParticipantEntityConfiguration : IEntityTypeConfiguration<Domain.Participant>
    {
        public void Configure(EntityTypeBuilder<Domain.Participant> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email)
                .HasMaxLength(200).IsRequired();
            builder.Property(e => e.Address)
                .HasMaxLength(200).IsRequired();
            builder.Property(e => e.Phone)
                .HasMaxLength(20).IsRequired();
            builder.Property(e => e.UserId)
                .HasMaxLength(100).IsRequired();
            
            builder.HasMany(m => m.TalkParticipants)
                .WithOne(m => m.Participant)
                .HasForeignKey(m => m.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
using Convention.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class TalkEntityConfiguration: IEntityTypeConfiguration<Domain.Talk>
    {
        public void Configure(EntityTypeBuilder<Domain.Talk> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Status).HasDefaultValue(TalkStatus.Pending)
                .IsRequired();
            builder.Property(e => e.AmountOfSeats).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.ImageUrl)
                .HasMaxLength(255).IsRequired();
         
            builder.HasMany(m => m.TalkParticipants)
                .WithOne(m => m.Talk)
                .HasForeignKey(m => m.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
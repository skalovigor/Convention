using Convention.Domain.Enums;
using Convention.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class TalkEntityConfiguration: IEntityTypeConfiguration<Talk>
    {
        public void Configure(EntityTypeBuilder<Talk> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Name)
                .HasMaxLength(50).IsRequired();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.Property(e => e.Status).HasDefaultValue(TalkStatus.Pending)
                .IsRequired();
            builder.Property(e => e.AmountOfSeats).IsRequired();
            builder.Property(e => e.Description).IsRequired();
         
            builder.HasMany(m => m.TalkParticipants)
                .WithOne(m => m.Talk)
                .HasForeignKey(m => m.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
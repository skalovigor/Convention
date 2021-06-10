using Convention.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Convention.DAL.EntityConfigurations
{
    internal sealed class TalkParticipantEntityConfiguration: IEntityTypeConfiguration<TalkParticipant>
    {
        public void Configure(EntityTypeBuilder<TalkParticipant> builder)
        {
            builder.HasKey(m=> m.Id);
            builder.Property(e => e.TalkId).IsRequired();
            builder.Property(e => e.ParticipantId).IsRequired();
        }
    }
}
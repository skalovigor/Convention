using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories
{
    internal class ParticipantRepository : Repository<Guid, Domain.Participant>,  IParticipantRepository
    {
        public ParticipantRepository(DbSet<Domain.Participant> dbSet) : base(dbSet)
        {
        }
    }
}
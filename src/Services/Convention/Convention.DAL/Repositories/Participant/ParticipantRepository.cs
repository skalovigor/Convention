using System;
using Convention.Common.Repository;
using Convention.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories
{
    internal class ParticipantRepository : Repository<Guid, Participant>,  IParticipantRepository
    {
        public ParticipantRepository(DbSet<Participant> dbSet) : base(dbSet)
        {
        }
    }
}
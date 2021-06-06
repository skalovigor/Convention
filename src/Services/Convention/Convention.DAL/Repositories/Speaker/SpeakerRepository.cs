using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories.Speaker
{
    public class SpeakerRepository : Repository<Guid, Domain.Speaker>,  ISpeakerRepository
    {
        public SpeakerRepository(DbSet<Domain.Speaker> dbSet) : base(dbSet)
        {
        }
    }
}
using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories.Speaker
{
    public class SpeakerRepository : Repository<Guid, Domain.Models.Speaker>,  ISpeakerRepository
    {
        public SpeakerRepository(DbSet<Domain.Models.Speaker> dbSet) : base(dbSet)
        {
        }
    }
}
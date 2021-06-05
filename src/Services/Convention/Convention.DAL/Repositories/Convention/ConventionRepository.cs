using System;
using System.Threading.Tasks;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories
{
    internal class ConventionRepository : Repository<Guid, Domain.Convention>,  IConventionRepository
    {
        public ConventionRepository(DbSet<Domain.Convention> dbSet) : base(dbSet)
        {
        }

        public async Task<Domain.Convention> GetWithParticipantsAsync(Guid id)
        {
            var result = await DbSet
                .Include(m => m.Participants)
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }
    }
}
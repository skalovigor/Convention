using System;
using System.Threading.Tasks;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories
{
    internal class ConventionRepository : Repository<Guid, Domain.Models.Convention>,  IConventionRepository
    {
        public ConventionRepository(DbSet<Domain.Models.Convention> dbSet) : base(dbSet)
        {
        }

        public async Task<Domain.Models.Convention> GetWithParticipantsAsync(Guid id)
        {
            var result = await DbSet
                .Include(m => m.Participants)
                .FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }
    }
}
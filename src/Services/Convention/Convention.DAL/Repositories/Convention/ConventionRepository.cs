using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories
{
    internal class ConventionRepository : Repository<Guid, Domain.Convention>,  IConventionRepository
    {
        public ConventionRepository(DbSet<Domain.Convention> dbSet) : base(dbSet)
        {
        }
    }
}
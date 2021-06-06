using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories.Talk
{
    public class TalkRepository : Repository<Guid, Domain.Talk>,  ITalkRepository
    {
        public TalkRepository(DbSet<Domain.Talk> dbSet) : base(dbSet)
        {
        }
    }
}
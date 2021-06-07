using System;
using Convention.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Convention.DAL.Repositories.Talk
{
    public class TalkRepository : Repository<Guid, Domain.Models.Talk>,  ITalkRepository
    {
        public TalkRepository(DbSet<Domain.Models.Talk> dbSet) : base(dbSet)
        {
        }
    }
}
using System;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories
{
    public interface IConventionRepository : IRepository<Guid, Domain.Convention>
    {
        
    }
}
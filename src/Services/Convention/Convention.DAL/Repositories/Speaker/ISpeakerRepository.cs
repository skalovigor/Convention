using System;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories.Speaker
{
    public interface ISpeakerRepository : IRepository<Guid, Domain.Speaker>
    {
        
    }
}
using System;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories
{
    public interface IParticipantRepository : IRepository<Guid, Domain.Participant>
    {
        
    }
}
using System;
using Convention.Common.Repository;
using Convention.Domain.Models;

namespace Convention.DAL.Repositories
{
    public interface IParticipantRepository : IRepository<Guid, Participant>
    {
        
    }
}
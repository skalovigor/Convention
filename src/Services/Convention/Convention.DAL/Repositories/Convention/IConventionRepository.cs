using System;
using System.Threading.Tasks;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories
{
    public interface IConventionRepository : IRepository<Guid, Domain.Convention>
    {
        Task<Domain.Convention> GetWithParticipantsAsync(Guid id);
    }
}
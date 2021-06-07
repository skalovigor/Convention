using System;
using System.Threading.Tasks;
using Convention.Common.Repository;

namespace Convention.DAL.Repositories
{
    public interface IConventionRepository : IRepository<Guid, Domain.Models.Convention>
    {
        Task<Domain.Models.Convention> GetWithParticipantsAsync(Guid id);
    }
}
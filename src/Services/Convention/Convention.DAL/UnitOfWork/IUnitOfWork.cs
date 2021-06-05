using System;
using System.Threading.Tasks;
using Convention.DAL.Repositories;

namespace Convention.DAL
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IConventionRepository ConventionRepo { get; }
        IParticipantRepository ParticipantRepo { get; }
        Task SubmitChanges();
    }
}
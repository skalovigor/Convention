using System;
using System.Threading.Tasks;
using Convention.DAL.Repositories;
using Convention.DAL.Repositories.Talk;

namespace Convention.DAL
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IConventionRepository ConventionRepo { get; }
        IParticipantRepository ParticipantRepo { get; }
        ITalkRepository TalkRepo { get; }
        Task SubmitChanges();
    }
}
using System.Threading.Tasks;
using Convention.DAL.Repositories;

namespace Convention.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ConventionDbContext _dbContext;

        public UnitOfWork(ConventionDbContext dbContext)
        {
            _dbContext = dbContext;
            ConventionRepo = new ConventionRepository(dbContext.Conventions);
            ParticipantRepo = new ParticipantRepository(dbContext.Participant);
        }

        public IConventionRepository ConventionRepo { get; set; }
        public IParticipantRepository ParticipantRepo { get; set; }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.SaveChanges();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_dbContext != null)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task SubmitChanges()
            => _dbContext.SaveChangesAsync();
    }
}
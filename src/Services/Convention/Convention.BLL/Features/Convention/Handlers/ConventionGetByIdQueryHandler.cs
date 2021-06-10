using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Query;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Handlers
{
    internal class ConventionGetByIdQueryHandler : IRequestHandler<ConventionGetByIdQuery, Domain.Models.Convention>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionGetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Domain.Models.Convention> Handle(ConventionGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ConventionRepo.GetAsync(request.Id);
            return result;
        }
    }
}
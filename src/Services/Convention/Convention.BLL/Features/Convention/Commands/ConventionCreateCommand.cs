using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Commands
{
    public record ConventionCreateCommand : IRequest,
        IValidateRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
    }
    
    internal class ConventionCreateCommandHandler : IRequestHandler<ConventionCreateCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public ConventionCreateCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }
        
        public Task<Unit> Handle(ConventionCreateCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWOrk = _unitOfWorkAccessor.UnitOfWork;
            
            unitOfWOrk.ConventionRepo.Add(new Domain.Convention
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Information = request.Information
            });
            
            return Unit.Task;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Commands
{
    public record ConventionCreateCommand : IRequest<Guid>,
        IValidateRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Information { get; set; }
        public string BannerUrl { get; set; }
        public string Address { get; set; }
    }
    
    internal class ConventionCreateCommandHandler : IRequestHandler<ConventionCreateCommand, Guid>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public ConventionCreateCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }
        
        public Task<Guid> Handle(ConventionCreateCommand request, CancellationToken cancellationToken)
        {
            using var unitOfWOrk = _unitOfWorkAccessor.UnitOfWork;

            var entity = new Domain.Convention
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Information = request.Information,
                BannerUrl = request.BannerUrl,
                Address = request.Address
            };
            unitOfWOrk.ConventionRepo.Add(entity);
            
            return Task.FromResult(entity.Id);
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Convention.Handlers
{
    internal class ConventionCreateCommandHandler : IRequestHandler<ConventionCreateCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConventionCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Guid> Handle(ConventionCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Convention
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Information = request.Information,
                BannerUrl = request.BannerUrl,
                Address = request.Address
            };
            _unitOfWork.ConventionRepo.Add(entity);
            await _unitOfWork.SubmitChanges();
            
            return entity.Id;
        }
    }
}
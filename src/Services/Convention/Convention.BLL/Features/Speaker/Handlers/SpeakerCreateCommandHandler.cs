using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    internal class SpeakerCreateCommandHandler : IRequestHandler<SpeakerCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SpeakerCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Models.Speaker
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Approved = false,
                Position = request.Position,
                ProfileUrl = request.ProfileUrl,
                UserId = request.UserId
            };
            _unitOfWork.SpeakerRepo.Add(entity);
            await _unitOfWork.SubmitChanges();
            return Unit.Value;
        }
    }
}
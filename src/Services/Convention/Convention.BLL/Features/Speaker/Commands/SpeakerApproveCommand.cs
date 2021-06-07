using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerApproveCommand(Guid SpeakerId) : IRequest
    {
        public static SpeakerApproveCommand Of(Guid speakerId)
            => new(speakerId);
    }

    internal class SpeakerApproveCommandHandler : IRequestHandler<SpeakerApproveCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public SpeakerApproveCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public async Task<Unit> Handle(SpeakerApproveCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _unitOfWorkAccessor.UnitOfWork;

            var speaker = await unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            speaker.Approved = true;
            unitOfWork.SpeakerRepo.Update(speaker);

            return Unit.Value; 
        }
    }
}
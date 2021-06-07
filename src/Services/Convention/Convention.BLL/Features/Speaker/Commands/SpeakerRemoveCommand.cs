using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Commands
{
    //TODO: validation
    public record SpeakerRemoveCommand(Guid SpeakerId) : IRequest
    {
        public static SpeakerRemoveCommand Of(Guid speakerId)
            => new(speakerId);
    }

    internal class TalkRemoveCommandHandler : IRequestHandler<SpeakerRemoveCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public TalkRemoveCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public async Task<Unit> Handle(SpeakerRemoveCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _unitOfWorkAccessor.UnitOfWork;

            var speaker = await unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            unitOfWork.SpeakerRepo.Remove(speaker);

            return Unit.Value; 
        }
    }
}
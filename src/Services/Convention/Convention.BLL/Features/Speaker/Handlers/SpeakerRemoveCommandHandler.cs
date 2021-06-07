using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    internal class SpeakerRemoveCommandHandler : IRequestHandler<SpeakerRemoveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerRemoveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SpeakerRemoveCommand request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            _unitOfWork.SpeakerRepo.Remove(speaker);
            await _unitOfWork.SubmitChanges();

            return Unit.Value; 
        }
    }
}
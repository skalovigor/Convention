using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Speaker.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Speaker.Handlers
{
    internal class SpeakerApproveCommandHandler : IRequestHandler<SpeakerApproveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeakerApproveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SpeakerApproveCommand request, CancellationToken cancellationToken)
        {
            var speaker = await _unitOfWork.SpeakerRepo.GetAsync(request.SpeakerId);
            speaker.Approved = true;
            _unitOfWork.SpeakerRepo.Update(speaker);
            await _unitOfWork.SubmitChanges();
            
            return Unit.Value; 
        }
    }
}
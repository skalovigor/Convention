using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Commands;
using Convention.DAL;
using Convention.Domain.Enums;
using MediatR;

namespace Convention.BLL.Features.Talk.Handlers
{
    internal class TalkApproveCommandHandler : IRequestHandler<TalkApproveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalkApproveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(TalkApproveCommand request, CancellationToken cancellationToken)
        {
            var talk = await _unitOfWork.TalkRepo.GetAsync(request.TalkId);
            talk.Status = TalkStatus.Approved;
            
            _unitOfWork.TalkRepo.Update(talk);
            
            await _unitOfWork.SubmitChanges();
            
            return Unit.Value; 
        }
    }
}
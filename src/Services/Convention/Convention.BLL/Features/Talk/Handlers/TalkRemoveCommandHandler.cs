using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Commands;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Handlers
{
    internal class TalkRemoveCommandHandler : IRequestHandler<TalkRemoveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalkRemoveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(TalkRemoveCommand request, CancellationToken cancellationToken)
        {
            var talk = await _unitOfWork.TalkRepo.GetAsync(request.TalkId);
            _unitOfWork.TalkRepo.Remove(talk);
            await _unitOfWork.SubmitChanges();

            return Unit.Value; 
        }
    }
}
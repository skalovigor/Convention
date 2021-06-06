using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using Convention.Domain.Enums;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkApproveCommand(Guid TalkId) : IRequest,
        IValidateRequest
    {
        public static TalkApproveCommand Of(Guid talkId)
            => new(talkId);
    }

    internal class TalkApproveCommandHandler : IRequestHandler<TalkApproveCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public TalkApproveCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public async Task<Unit> Handle(TalkApproveCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _unitOfWorkAccessor.UnitOfWork;

            var talk = await unitOfWork.TalkRepo.GetAsync(request.TalkId);
            talk.Status = TalkStatus.Approved;
            unitOfWork.TalkRepo.Update(talk);

            return Unit.Value; 
        }
    }
}
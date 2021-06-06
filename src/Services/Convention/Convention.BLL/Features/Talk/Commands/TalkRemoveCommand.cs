using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Behaviours;
using Convention.DAL;
using MediatR;

namespace Convention.BLL.Features.Talk.Commands
{
    public record TalkRemoveCommand(Guid TalkId) : IRequest,
        IValidateRequest
    {
        public static TalkRemoveCommand Of(Guid talkId)
            => new(talkId);
    }

    internal class TalkRemoveCommandHandler : IRequestHandler<TalkRemoveCommand>
    {
        private readonly IUnitOfWorkAccessor _unitOfWorkAccessor;

        public TalkRemoveCommandHandler(IUnitOfWorkAccessor unitOfWorkAccessor)
        {
            _unitOfWorkAccessor = unitOfWorkAccessor;
        }

        public async Task<Unit> Handle(TalkRemoveCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = _unitOfWorkAccessor.UnitOfWork;

            var talk = await unitOfWork.TalkRepo.GetAsync(request.TalkId);
            unitOfWork.TalkRepo.Remove(talk);

            return Unit.Value; 
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Queries;
using Convention.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Convention.BLL.Features.Talk.Validators
{
    public class TalkApproveCommandValidator : AbstractValidator<TalkApproveCommand>
    {
        private readonly IMediator _mediator;

        public TalkApproveCommandValidator(IMediator mediator)
        {
            _mediator = mediator;
            RuleFor(m => m.TalkId)
                .NotEmpty()
                .NotNull()
                .MustAsync(TalkMustExist)
                .WithErrorCode("Talk does not exist")
                .MustAsync(TalkMustNotBeApproved)
                .WithErrorCode("Talk already approved");
        }
        
        private async Task<bool> TalkMustExist(TalkApproveCommand command,
            Guid talkId,
            ValidationContext<TalkApproveCommand> context,
            CancellationToken cancellationToken)
        {
            var talk = await _mediator.Send(TalkGetByIdQuery.Of(command.TalkId), cancellationToken);
            return talk != null;
        }
        
        private async Task<bool> TalkMustNotBeApproved(TalkApproveCommand command,
            Guid talkId,
            ValidationContext<TalkApproveCommand> context,
            CancellationToken cancellationToken)
        {
            var talk = await _mediator.Send(TalkGetByIdQuery.Of(command.TalkId), cancellationToken);
            return talk != null && talk.Status != TalkStatus.Approved;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Talk.Commands;
using Convention.BLL.Features.Talk.Queries;
using FluentValidation;
using MediatR;

namespace Convention.BLL.Features.Talk.Validators
{
    public class TalkRemoveCommandValidator : AbstractValidator<TalkRemoveCommand>
    {
        private readonly IMediator _mediator;

        public TalkRemoveCommandValidator(IMediator mediator)
        {
            _mediator = mediator;
            RuleFor(m => m.TalkId)
                .NotEmpty()
                .NotNull()
                .MustAsync(TalkMustExist)
                .WithErrorCode("Talk does not exist");
        }
        
        private async Task<bool> TalkMustExist(TalkRemoveCommand command,
            Guid talkId,
            ValidationContext<TalkRemoveCommand> context,
            CancellationToken cancellationToken)
        {
            var talk = await _mediator.Send(TalkGetByIdQuery.Of(command.TalkId), cancellationToken);
            return talk != null;
        }
    }
}
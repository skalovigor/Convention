using System;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Query;
using Convention.BLL.Features.Speaker.Queries;
using Convention.BLL.Features.Talk.Commands;
using FluentValidation;
using MediatR;

namespace Convention.BLL.Features.Talk.Validators
{
    public class TalkCreateCommandValidator : AbstractValidator<TalkCreateCommand>
    {
        private readonly IMediator _mediator;

        public TalkCreateCommandValidator(IMediator mediator)
        {
            _mediator = mediator;
            
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(m => m.Description)
                .NotEmpty()
                .NotNull();
            RuleFor(m => m.ImageUrl)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);
            RuleFor(m => m.Date)
                .NotEmpty()
                .NotNull()
                .MustAsync(DateMustBeDuringConventionDates);
            RuleFor(m => m.AmountOfSeats)
                .GreaterThanOrEqualTo(5);
            RuleFor(m => m.ConventionId)
                .NotEmpty()
                .NotNull()
                .MustAsync(ConventionMustExist);
            RuleFor(m => m.SpeakerId)
                .NotEmpty()
                .NotNull()
                .MustAsync(SpeakerMustExist);
        }
        
        //TODO: should be shared validator
        private async Task<bool> ConventionMustExist(TalkCreateCommand command,
            Guid conventionId,
            ValidationContext<TalkCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var convention = await _mediator.Send(ConventionGetByIdQuery.Of(command.ConventionId), cancellationToken);
            return convention != null;
        }
        
        private async Task<bool> DateMustBeDuringConventionDates(TalkCreateCommand command,
            DateTime date,
            ValidationContext<TalkCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var convention = await _mediator.Send(ConventionGetByIdQuery.Of(command.ConventionId), cancellationToken);
            return convention.StartDate <= date && date <= convention.EndDate;
        }
        
        private async Task<bool> SpeakerMustExist(TalkCreateCommand command,
            Guid conventionId,
            ValidationContext<TalkCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var speaker = await _mediator.Send(SpeakerGetByIdQuery.Of(command.SpeakerId), cancellationToken);
            return speaker != null;
        }
    }
}
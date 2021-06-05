using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Convention.BLL.Features.Convention.Query;
using Convention.BLL.Features.Participant.Commands;
using FluentValidation;
using MediatR;

namespace Convention.BLL.Features.Validators
{
    public class ParticipantCreateCommandValidator : AbstractValidator<ParticipantCreateCommand>
    {
        private readonly IMediator _mediator;

        public ParticipantCreateCommandValidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(m => m.ConventionId)
                .NotEmpty()
                .NotNull()
                .MustAsync(ConventionMustExist)
                .WithMessage("Convention with id '{ConventionId}' does not exist")
                .MustAsync(ConventionMustBeActive)
                .WithMessage("Convention with id '{ConventionId}' is not active anymore");
            RuleFor(m => m.UserId)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200)
                .MustAsync(UserMustNotBeSubscribed)
                .WithMessage("User with id '{UserId}' is already participating convention");;
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(m => m.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(200);
            RuleFor(m => m.Phone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);
        }

        private async Task<bool> ConventionMustExist(ParticipantCreateCommand command,
            Guid conventionId,
            ValidationContext<ParticipantCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var convention = await _mediator.Send(ConventionGetByIdQuery.Of(conventionId), cancellationToken);
            return convention != null;
        }

        private async Task<bool> ConventionMustBeActive(ParticipantCreateCommand command,
            Guid conventionId,
            ValidationContext<ParticipantCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var convention = await _mediator.Send(ConventionGetByIdQuery.Of(conventionId), cancellationToken);
            return convention != null && convention.EndDate > DateTime.Now;
        }

        private async Task<bool> UserMustNotBeSubscribed(ParticipantCreateCommand command,
            string userId,
            ValidationContext<ParticipantCreateCommand> context,
            CancellationToken cancellationToken)
        {
            var convention = await _mediator.Send(ConventionGetByIdWithParticipantsQuery.Of(command.ConventionId),
                cancellationToken);
            return convention != null && convention.Participants.All(m => m.UserId != userId);
        }
    }
}
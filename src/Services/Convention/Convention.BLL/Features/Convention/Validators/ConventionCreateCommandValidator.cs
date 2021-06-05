using System;
using Convention.BLL.Features.Convention.Commands;
using FluentValidation;

namespace Convention.BLL.Features.Convention.Validators
{
    public class ConventionCreateCommandValidator : AbstractValidator<ConventionCreateCommand>
    {
        public ConventionCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(m => m.Information)
                .NotEmpty()
                .NotNull();
            RuleFor(m => m.StartDate)
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(m => m.EndDate)
                .NotNull()
                .GreaterThanOrEqualTo(m=> m.EndDate);
        }
    }
}
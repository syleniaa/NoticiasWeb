using System;
using FluentValidation;

namespace Application.Traces.Commands
{
    public class UpdateTraceCommandValidator : AbstractValidator<UpdateTraceCommand>
    {
        public UpdateTraceCommandValidator()
        {
            RuleFor(v => v.Url)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.")
                .NotEmpty().WithMessage("Url required");
        }
    }
}

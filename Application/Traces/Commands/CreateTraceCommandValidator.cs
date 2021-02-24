using FluentValidation;

namespace Application.Traces.Commands
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTraceCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Url)
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.")
                .NotEmpty().WithMessage("Url required");
        }
    }
}

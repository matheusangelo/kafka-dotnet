using App.Domain.Entities;
using FluentValidation;

namespace App.Domain.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Body).NotEmpty().WithMessage("Body is required.");
            RuleFor(x => x.Body).NotNull().WithMessage("Body is required.");
        }
    }
}

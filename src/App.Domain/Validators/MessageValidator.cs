using App.Domain;
using FluentValidation;

namespace Name
{
    public class MessageValidator : AbstractValidator<Message>
{
    public MessageValidator()
    {
        RuleFor(x => x.Body).NotEmpty().WithMessage("Body is required.");
    }
}
}

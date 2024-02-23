using AccountStatements.Domain.Commands;
using FluentValidation;

namespace AccountStatements.Domain.Configurations.Validations
{
    public class CreateSettingCommandValidator : AbstractValidator<CreateSettingCommand>
    {
        public CreateSettingCommandValidator()
        {
            RuleFor(command => command.MinBalancePct)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(command => command.InterestPct)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}

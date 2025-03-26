using FluentValidation;

namespace MovieStore.App.CustomerOperations.Commands;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Model.Name)
            .MinimumLength(2)
            .Matches("^[a-zA-Z]+$");
        RuleFor(x => x.Model.Surname).MinimumLength(2);
        RuleFor(x => x.Model.Email)
            .EmailAddress();
        RuleFor(x => x.Model.Password)
            .Matches("^(?=.*[0-9])[a-zA-Z0-9]{8,}$");
    }
}
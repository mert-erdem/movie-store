using FluentValidation;

namespace MovieStore.App.DirectorOperations.Commands.CreateDirectors;

public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidator()
    {
        RuleFor(x => x.Model.Name).MinimumLength(2);
        RuleFor(x => x.Model.Surname).MinimumLength(2);
    }
}
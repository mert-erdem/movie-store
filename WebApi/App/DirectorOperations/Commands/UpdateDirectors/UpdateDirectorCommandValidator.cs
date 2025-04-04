using FluentValidation;

namespace MovieStore.App.DirectorOperations.Commands.UpdateDirectors;

public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Model.Name).MinimumLength(2);
        RuleFor(x => x.Model.Surname).MinimumLength(2);
    }
}
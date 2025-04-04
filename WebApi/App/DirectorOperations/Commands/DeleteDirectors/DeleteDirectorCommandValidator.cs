using FluentValidation;

namespace MovieStore.App.DirectorOperations.Commands.DeleteDirectors;

public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
{
    public DeleteDirectorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
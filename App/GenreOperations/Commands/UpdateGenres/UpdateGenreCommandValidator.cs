using FluentValidation;

namespace MovieStore.App.GenreOperations.Commands.UpdateGenres;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Model.Name).MinimumLength(3);
    }
}
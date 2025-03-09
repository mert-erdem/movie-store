using FluentValidation;

namespace MovieStore.App.GenreOperations.Commands.DeleteGenres;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
using FluentValidation;

namespace MovieStore.App.GenreOperations.Commands.CreateGenres;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(x => x.Model.Name).MinimumLength(3);
    }
}
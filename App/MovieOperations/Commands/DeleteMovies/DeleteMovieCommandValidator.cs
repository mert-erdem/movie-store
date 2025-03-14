using FluentValidation;

namespace MovieStore.App.MovieOperations.Commands.DeleteMovies;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
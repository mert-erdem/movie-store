using FluentValidation;

namespace MovieStore.App.MovieOperations.Commands.UpdateMovies;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Model.Name).MinimumLength(2);
        RuleFor(x => x.Model.ReleaseDate).LessThanOrEqualTo(DateTime.Today);
        RuleFor(x => x.Model.GenreId).GreaterThan(0);
        RuleFor(x => x.Model.DirectorId).GreaterThan(0);
        RuleFor(x => x.Model.ActorIdList).NotEmpty();
        RuleFor(x => x.Model.Price).GreaterThan(0);
    }
}
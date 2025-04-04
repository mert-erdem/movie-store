using FluentValidation;

namespace MovieStore.App.MovieOperations.Queries;

public class GetMovieQueryValidator : AbstractValidator<GetMovieQuery>
{
    public GetMovieQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
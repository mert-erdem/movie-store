using FluentValidation;

namespace MovieStore.App.GenreOperations.Queries;

public class GetGenreQueryValidator : AbstractValidator<GetGenreQuery>
{
    public GetGenreQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
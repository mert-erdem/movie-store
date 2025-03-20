using FluentValidation;

namespace MovieStore.App.DirectorOperations.Queries;

public class GetDirectorQueryValidator : AbstractValidator<GetDirectorQuery>
{
    public GetDirectorQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
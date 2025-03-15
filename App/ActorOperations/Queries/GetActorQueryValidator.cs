using FluentValidation;

namespace MovieStore.App.ActorOperations.Queries;

public class GetActorQueryValidator : AbstractValidator<GetActorQuery>
{
    public GetActorQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
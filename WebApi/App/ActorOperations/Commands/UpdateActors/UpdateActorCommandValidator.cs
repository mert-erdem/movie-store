using FluentValidation;

namespace MovieStore.App.ActorOperations.Commands.UpdateActors;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Model.Name).MinimumLength(2);
        RuleFor(x => x.Model.Surname).MinimumLength(2);
    }
}
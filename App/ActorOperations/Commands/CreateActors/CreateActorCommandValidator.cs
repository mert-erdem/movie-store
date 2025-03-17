using FluentValidation;

namespace MovieStore.App.ActorOperations.Commands.CreateActors;

public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidator()
    {
        RuleFor(x => x.Model.Name).MinimumLength(2);
        RuleFor(x => x.Model.Surname).MinimumLength(2);
    }
}
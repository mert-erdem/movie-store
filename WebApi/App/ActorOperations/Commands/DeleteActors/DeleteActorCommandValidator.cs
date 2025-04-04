using FluentValidation;

namespace MovieStore.App.ActorOperations.Commands.DeleteActors;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
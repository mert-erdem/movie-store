using FluentValidation;

namespace MovieStore.App.PurchaseOperations;

public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseCommandValidator()
    {
        RuleFor(x => x.Model.CustomerId).GreaterThan(0);
        RuleFor(x => x.Model.MovieId).GreaterThan(0);
    }
}
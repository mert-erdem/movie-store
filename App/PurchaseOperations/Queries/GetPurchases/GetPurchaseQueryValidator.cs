using FluentValidation;

namespace MovieStore.App.PurchaseOperations.Queries.GetPurchases;

public class GetPurchaseQueryValidator : AbstractValidator<GetPurchaseQuery>
{
    public GetPurchaseQueryValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
    }
}
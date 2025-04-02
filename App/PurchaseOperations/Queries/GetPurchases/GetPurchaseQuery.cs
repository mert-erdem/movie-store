using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.App.PurchaseOperations.Queries.GetPurchases;

public class GetPurchaseQuery
{
    public int CustomerId { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPurchaseQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns purchases of the customer that has given ID.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public List<PurchaseViewModel> Handle()
    {
        var customer = _dbContext.Customers
            .SingleOrDefault(x => x.Id == CustomerId);

        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found!");
        }
        
        var purchases = _dbContext.Purchases
            .Include(x => x.Movie)
            .Where(x => x.CustomerId == CustomerId);
        
        var purchaseViewModels = _mapper.Map<List<PurchaseViewModel>>(purchases);
        
        return purchaseViewModels;
    }

    public class PurchaseViewModel
    {
        public required string MovieName { get; set; }

        public double Price { get; set; }

        public DateTime Time { get; set; }
    }
}
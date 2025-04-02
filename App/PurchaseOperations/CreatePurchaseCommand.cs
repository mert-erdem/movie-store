using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.PurchaseOperations;

public class CreatePurchaseCommand
{
    public CreatePurchaseInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreatePurchaseCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == Model.CustomerId);

        if (customer is null)
        {
            throw new InvalidOperationException("Customer not found!");
        }
        
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Model.MovieId);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }
        
        var purchase = _mapper.Map<Purchase>(Model);
        purchase.Price = movie.Price;
        purchase.Time = DateTime.Now;
        
        _dbContext.Purchases.Add(purchase);
        _dbContext.SaveChanges();
    }

    public class CreatePurchaseInputModel
    {
        public int CustomerId { get; set; }

        public int MovieId { get; set; }
    }
}
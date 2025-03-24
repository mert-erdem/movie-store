using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.CustomerOperations;

public class CreateCustomerCommand
{
    public CreateCustomerInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var customer = _dbContext.Customers.SingleOrDefault(x => x.Email == Model.Email);

        if (customer is not null)
        {
            throw new InvalidOperationException("Customer with same email already exists!");
        }
        
        var newCustomer = _mapper.Map<Customer>(Model);
        
        _dbContext.Customers.Add(newCustomer);
        _dbContext.SaveChanges();
    }

    public class CreateCustomerInputModel
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public List<int>? PurchasedMovieIds { get; set; }

        public List<int>? FavouriteGenreIds { get; set; }
    }
}
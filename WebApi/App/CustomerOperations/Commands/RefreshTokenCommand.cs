using MovieStore.App.TokenOperations;
using MovieStore.DbOperations;

namespace MovieStore.App.CustomerOperations.Commands;

public class RefreshTokenCommand
{
    public string RefreshToken { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var customer = _dbContext.Customers.FirstOrDefault(x =>
            x.RefreshToken == RefreshToken && 
            x.RefreshTokenExpireTime > DateTime.Now);

        if (customer is null)
        {
            throw new InvalidOperationException("Invalid refresh token!");
        }

        var tokenHandler = new TokenHandler(_configuration);
        var token = tokenHandler.CreateAccessToken();

        customer.RefreshToken = token.RefreshToken;
        customer.RefreshTokenExpireTime = token.ExpireTime.AddMinutes(5);
        
        _dbContext.SaveChanges();

        return token;
    }
}
using MovieStore.App.TokenOperations;
using MovieStore.DbOperations;

namespace MovieStore.App.CustomerOperations.Commands;

public class CreateTokenCommand
{
    public CreateTokenModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public CreateTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);

        if (user is null)
        {
            throw new InvalidOperationException("Invalid email or password");
        }

        var tokenHandler = new TokenHandler(_configuration);
        var token = tokenHandler.CreateAccessToken();

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireTime = token.ExpireTime.AddMinutes(5);
        
        _dbContext.SaveChanges();

        return token;
    }
}

public class CreateTokenModel()
{
    public string Email { get; set; }

    public string Password { get; set; }
}
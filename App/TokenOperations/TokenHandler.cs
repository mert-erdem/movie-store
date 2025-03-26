using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MovieStore.App.TokenOperations;

public class TokenHandler
{
    private readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token CreateAccessToken()
    {
        var token = new Token();
        
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        token.ExpireTime = DateTime.Now.AddMinutes(15);
        
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["Token:Issuer"], 
            audience: _configuration["Token:Audience"], 
            expires: token.ExpireTime, 
            notBefore: DateTime.Now, 
            signingCredentials: signingCredentials
        );
        
        // Create Tokens
        var tokenHandler = new JwtSecurityTokenHandler();
        token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
        token.RefreshToken = CreateRefreshToken();

        return token;
    }

    private string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}
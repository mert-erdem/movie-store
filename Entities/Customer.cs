using System.ComponentModel.DataAnnotations;

namespace MovieStore.Entities;

public class Customer
{
    [Key] public int Id { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
    
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpireTime { get; set; }

    public List<int>? PurchasedMovieIds { get; set; }

    public List<int>? FavouriteGenreIds { get; set; }
}
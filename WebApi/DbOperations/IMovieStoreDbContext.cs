using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations;

public interface IMovieStoreDbContext
{
    public DbSet<Actor> Actors { get; set; }

    public DbSet<Director> Directors { get; set; }
    
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<MovieActor> MovieActors { get; set; }
    
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Purchase> Purchases { get; set; }

    int SaveChanges();
}
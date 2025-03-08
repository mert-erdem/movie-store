using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var dbContext = new MovieStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>());
        
        dbContext.Genres.AddRange(
            new Genre
            {
                Id = 1,
                Name = "Sci-Fi"
            },
            new Genre
            {
                Id = 2,
                Name = "Biography"
            },
            new Genre
            {
                Id = 3,
                Name = "Action"
            });
        
        dbContext.Actors.AddRange(
            new Actor
            {
                Id = 1,
                Name = "Tom",
                Surname = "Cruise"
            },
            new Actor
            {
                Id = 2,
                Name = "Christian",
                Surname = "Bale"
            },new Actor
            {
                Id = 3,
                Name = "Tom",
                Surname = "Hanks"
            });
        
        dbContext.Directors.AddRange(
            new Director
            {
                Id = 1,
                Name = "Christopher",
                Surname = "Nolan"
            },
            new Director
            {
                Id = 2,
                Name = "Clint",
                Surname = "Eastwood"
            },
            new Director
            {
                Id = 3,
                Name = "Joseph",
                Surname = "Kosinski"
            });
        
        dbContext.Movies.AddRange(
            new Movie
            {
                Id = 1,
                Name = "The Dark Knight",
                Year = new DateTime(2008, 01, 01),
                GenreId = 3,
                DirectorId = 1,
                Price = 3.99f
            },
            new Movie
            {
                Id = 2,
                Name = "Sully",
                Year = new DateTime(2016, 01, 01),
                GenreId = 2,
                DirectorId = 2,
                Price = 2.99f
            },
            new Movie
            {
                Id = 3,
                Name = "Oblivion",
                Year = new DateTime(2013, 01, 01),
                GenreId = 1,
                DirectorId = 3,
                Price = 1.99f
            });
        
        dbContext.MovieActors.AddRange(
            new MovieActor
            {
                ActorId = 2,
                MovieId = 1,
            },
            new MovieActor
            {
                ActorId = 3,
                MovieId = 2,
            },
            new MovieActor
            {
                ActorId = 1,
                MovieId = 3
            });
        
        dbContext.SaveChanges();
    }
}
using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.GenreOperations.Commands.UpdateGenres;

public class UpdateGenreCommand
{
    public int Id { get; set; }
    public UpdateGenreInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;

    public UpdateGenreCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);

        if (genre is null)
        {
            throw new InvalidOperationException("Genre not found!");
        }
        
        var sameGenreNameExists = _dbContext.Genres.Any(x => 
            x.Name.Equals(Model.Name, StringComparison.InvariantCultureIgnoreCase) && 
            x.Id != Id);

        if (sameGenreNameExists)
        {
            throw new InvalidOperationException("Genre already exists!");
        }
        
        genre.Name = Model.Name;
        
        _dbContext.SaveChanges();
    }

    public class UpdateGenreInputModel
    {
        public required string Name { get; set; }
    }
}
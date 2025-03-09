using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.GenreOperations.Commands.DeleteGenres;

public class DeleteGenreCommand
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteGenreCommand(IMovieStoreDbContext dbContext)
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
        
        _dbContext.Genres.Remove(genre);
        _dbContext.SaveChanges();
    }
}
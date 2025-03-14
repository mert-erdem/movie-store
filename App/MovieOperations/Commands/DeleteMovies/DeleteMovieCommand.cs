using MovieStore.DbOperations;

namespace MovieStore.App.MovieOperations.Commands.DeleteMovies;

public class DeleteMovieCommand
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteMovieCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Id);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }
        
        _dbContext.Movies.Remove(movie);
        
        _dbContext.SaveChanges();
    }
}
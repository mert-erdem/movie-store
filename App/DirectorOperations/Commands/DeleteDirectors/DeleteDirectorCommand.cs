using MovieStore.DbOperations;

namespace MovieStore.App.DirectorOperations.Commands.DeleteDirectors;

public class DeleteDirectorCommand
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.Id == Id);

        if (director is null)
        {
            throw new InvalidOperationException("Director not found!");
        }
        
        _dbContext.Directors.Remove(director);
        _dbContext.SaveChanges();
    }
}
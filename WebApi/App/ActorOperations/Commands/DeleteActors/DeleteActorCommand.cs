using MovieStore.DbOperations;

namespace MovieStore.App.ActorOperations.Commands.DeleteActors;

public class DeleteActorCommand
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteActorCommand(IMovieStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }
        
        _dbContext.Actors.Remove(actor);
        _dbContext.SaveChanges();
    }
}
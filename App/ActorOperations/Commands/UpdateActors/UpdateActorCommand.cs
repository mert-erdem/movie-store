using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.ActorOperations.Commands.UpdateActors;

public class UpdateActorCommand
{
    public int Id { get; set; }
    public UpdateActorInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }
        
        _mapper.Map(Model, actor);

        _dbContext.SaveChanges();
    }

    public class UpdateActorInputModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
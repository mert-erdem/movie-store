using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.ActorOperations.Commands.CreateActors;

public class CreateActorCommand
{
    public CreateActorInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var actor = _dbContext.Actors.SingleOrDefault(x => 
            x.Name == Model.Name && 
            x.Surname == Model.Surname); // Extra field needed

        if (actor is not null)
        {
            throw new InvalidOperationException("Actor already exists.");
        }
        
        var newActor = _mapper.Map<Actor>(Model);
        
        _dbContext.Actors.Add(newActor);
        _dbContext.SaveChanges();
    }

    public class CreateActorInputModel
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }
    }
}
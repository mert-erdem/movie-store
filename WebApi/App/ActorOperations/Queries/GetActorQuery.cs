using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.App.ActorOperations.Queries;

public class GetActorQuery
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ActorViewModel> Handle()
    {
        var actors = _dbContext.Actors
            .Include(x => x.MovieActors)
            .ThenInclude(x => x.Movie)
            .ToList();
        
        var actorViewModels = _mapper.Map<List<ActorViewModel>>(actors);
        
        return actorViewModels;
    }

    public ActorViewModel HandleWithId()
    {
        var actor = _dbContext.Actors
            .Include(x => x.MovieActors)
            .ThenInclude(x => x.Movie)
            .SingleOrDefault(x => x.Id == Id);

        if (actor is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }
        
        var actorViewModel = _mapper.Map<ActorViewModel>(actor);
        
        return actorViewModel;
    }
    
    public class ActorViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<string> Movies { get; set; } = new();
    }
}
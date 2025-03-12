using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.MovieOperations.Commands;

public class CreateMovieCommand
{
    public CreateMovieInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => 
            x.Name.Equals(Model.Name, StringComparison.InvariantCultureIgnoreCase));
        
        if (movie is not null)
        {
            throw new InvalidOperationException("Movie already exists!");
        }
        
        // var newMovie = _mapper.Map<Movie>(Model);
        
        var newMovie = new Movie
        {
            Name = Model.Name,
            ReleaseDate = Model.ReleaseDate,
            GenreId = Model.GenreId,
            DirectorId = Model.DirectorId,
            Price = Model.Price,
            MovieActors = Model.ActorIdList.Select(id => new MovieActor { ActorId = id }).ToList()
        };
        
        _dbContext.Movies.Add(newMovie);
        _dbContext.SaveChanges();
    }
    
    public class CreateMovieInputModel
    {
        public required string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        
        public int DirectorId { get; set; }

        public List<int> ActorIdList { get; set; } = new();

        public float Price { get; set; }
    }
}
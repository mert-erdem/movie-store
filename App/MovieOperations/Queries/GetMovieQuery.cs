using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.App.MovieOperations.Queries;

public class GetMovieQuery
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<MovieViewModel> Handle()
    {
        var movies = _dbContext.Movies
            .Include(x => x.Genre)
            .Include(x => x.Director)
            .Include(x => x.MovieActors)
            .ThenInclude(x => x.Actor)
            .OrderBy(x => x.Id)
            .ToList();
        
        var movieViewModels = _mapper.Map<List<MovieViewModel>>(movies);
        
        return movieViewModels;
    }

    public MovieViewModel HandleWithId()
    {
        var movie = _dbContext.Movies
            .Include(x => x.Genre)
            .Include(x => x.Director)
            .Include(x => x.MovieActors)
            .ThenInclude(x => x.Actor)
            .SingleOrDefault(x => x.Id == Id);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }
        
        var movieViewModel = _mapper.Map<MovieViewModel>(movie);
        
        return movieViewModel;
    }

    public class MovieViewModel
    {
        public required string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public string? Genre { get; set; }
        
        public string? Director { get; set; }

        public List<string> Actors { get; set; } = new();

        public float Price { get; set; }
    }
}
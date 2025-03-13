using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.MovieOperations.Commands.UpdateMovies;

public class UpdateMovieCommand
{
    public int Id { get; set; }
    public UpdateMovieInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies
            .Include(x => x.MovieActors)
            .SingleOrDefault(x => x.Id == Id);

        if (movie is null)
        {
            throw new InvalidOperationException("Movie not found!");
        }

        if (!CheckIfGenreExists(Model.GenreId))
        {
            throw new InvalidOperationException("The genre not found!");
        }

        if (!CheckIfDirectorExists(Model.DirectorId))
        {
            throw new InvalidOperationException("The director not found!");
        }
        
        _mapper.Map(Model, movie);
        
        // movie.Name = Model.Name;
        // movie.ReleaseDate = Model.ReleaseDate;
        // movie.Price = Model.Price;
        // movie.GenreId = Model.GenreId;
        // movie.DirectorId = Model.DirectorId;
        // movie.MovieActors = Model.ActorIdList.Select(x => new MovieActor
        // {
        //     ActorId = x
        // }).ToList();

        _dbContext.SaveChanges();
    }

    private bool CheckIfGenreExists(int genreId)
    {
        return _dbContext.Genres.Any(x => x.Id == genreId);
    }

    private bool CheckIfDirectorExists(int directorId)
    {
        return _dbContext.Directors.Any(x => x.Id == directorId);
    }

    public class UpdateMovieInputModel
    {
        public required string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        
        public int DirectorId { get; set; }
        
        public List<int> ActorIdList { get; set; } = new();

        public float Price { get; set; }
    }
}
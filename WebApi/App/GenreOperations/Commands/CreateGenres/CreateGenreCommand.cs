using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.GenreOperations.Commands.CreateGenres;

public class CreateGenreCommand
{
    public CreateGenreInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => 
            x.Name.Equals(Model.Name, StringComparison.InvariantCultureIgnoreCase));

        if (genre is not null)
        {
            throw new InvalidOperationException("Genre already exists!");
        }
        
        var genreModel = _mapper.Map<Genre>(Model);
        
        _dbContext.Genres.Add(genreModel);
        _dbContext.SaveChanges();
    }

    public class CreateGenreInputModel
    {
        public required string Name { get; set; }
    }
}
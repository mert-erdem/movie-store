using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.GenreOperations.Queries;

public class GetGenreQuery
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetGenreQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<GenreViewModel> Handle()
    {
        var genres = _dbContext.Genres.OrderBy(x => x.Id).ToList();
        var genreViewModels = _mapper.Map<List<GenreViewModel>>(genres);

        return genreViewModels;
    }

    public GenreViewModel HandleWithId()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Id);

        if (genre is null)
        {
            throw new InvalidOperationException("Genre not found for given Id!");
        }
        
        var genreViewModel = _mapper.Map<GenreViewModel>(genre);
        
        return genreViewModel;
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
    }
}
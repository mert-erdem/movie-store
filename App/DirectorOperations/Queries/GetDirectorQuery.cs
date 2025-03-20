using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.DirectorOperations.Queries;

public class GetDirectorQuery
{
    public int Id { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<DirectorViewModel> Handle()
    {
        var directors = _dbContext.Directors.ToList();
        var directorViewModels = _mapper.Map<List<DirectorViewModel>>(directors);
        
        return directorViewModels;
    }

    public DetailedDirectorViewModel HandleWithId()
    {
        var director = _dbContext.Directors
            .SingleOrDefault(x => x.Id == Id);

        if (director is null)
        {
            throw new InvalidOperationException("Actor not found!");
        }
        
        var directorViewModel = _mapper.Map<DetailedDirectorViewModel>(director);
        directorViewModel.Movies = _dbContext.Movies
            .Where(x => x.DirectorId == director.Id)
            .Select(x => x.Name)
            .ToList();
        
        return directorViewModel;
    }
    
    public class DirectorViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class DetailedDirectorViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        
        public List<string> Movies { get; set; }
    }
}
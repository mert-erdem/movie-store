using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.App.DirectorOperations.Commands.CreateDirectors;

public class CreateDirectorCommand
{
    public CreateDirectorInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => 
            x.Name == Model.Name && 
            x.Surname == Model.Surname); // Extra field needed

        if (director is not null)
        {
            throw new InvalidOperationException("Director already exists.");
        }
        
        var newDirector = _mapper.Map<Director>(Model);
        
        _dbContext.Directors.Add(newDirector);
        _dbContext.SaveChanges();
    }

    public class CreateDirectorInputModel
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }
    }
}
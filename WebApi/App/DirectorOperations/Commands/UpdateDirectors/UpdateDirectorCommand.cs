using AutoMapper;
using MovieStore.DbOperations;

namespace MovieStore.App.DirectorOperations.Commands.UpdateDirectors;

public class UpdateDirectorCommand
{
    public int Id { get; set; }
    public UpdateDirectorInputModel Model { get; set; }
    
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(x => x.Id == Id);

        if (director is null)
        {
            throw new InvalidOperationException("Director not found!");
        }
        
        _mapper.Map(Model, director);

        _dbContext.SaveChanges();
    }

    public class UpdateDirectorInputModel
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }
    }
}
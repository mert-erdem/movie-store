using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.DirectorOperations.Commands.CreateDirectors;
using MovieStore.App.DirectorOperations.Commands.UpdateDirectors;
using MovieStore.App.DirectorOperations.Queries;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class DirectorController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public DirectorController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var query = new GetDirectorQuery(_dbContext, _mapper);
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var query = new GetDirectorQuery(_dbContext, _mapper)
        {
            Id = id
        };
        
        var validator = new GetDirectorQueryValidator();
        validator.ValidateAndThrow(query);
        
        var result = query.HandleWithId();
        
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Add([FromBody] CreateDirectorCommand.CreateDirectorInputModel value)
    {
        var command = new CreateDirectorCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreateDirectorCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Director created!");
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateDirectorCommand.UpdateDirectorInputModel value)
    {
        var command = new UpdateDirectorCommand(_dbContext, _mapper)
        {
            Id = id,
            Model = value
        };
        
        var validator = new UpdateDirectorCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Director updated!");
    }
}
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.ActorOperations.Commands.CreateActors;
using MovieStore.App.ActorOperations.Queries;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ActorController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public ActorController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var query = new GetActorQuery(_dbContext, _mapper);
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var query = new GetActorQuery(_dbContext, _mapper)
        {
            Id = id
        };
        
        var validator = new GetActorQueryValidator();
        validator.ValidateAndThrow(query);
        
        var result = query.HandleWithId();
        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateActorCommand.CreateActorInputModel value)
    {
        var command = new CreateActorCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreateActorCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Actor created");
    }
}
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.MovieOperations.Commands;
using MovieStore.App.MovieOperations.Commands.CreateGenres;
using MovieStore.App.MovieOperations.Commands.UpdateMovies;
using MovieStore.App.MovieOperations.Queries;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class MovieController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public MovieController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var query = new GetMovieQuery(_dbContext, _mapper);
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var query = new GetMovieQuery(_dbContext, _mapper)
        {
            Id = id
        };
        
        var validator = new GetMovieQueryValidator();
        validator.ValidateAndThrow(query);
        
        var result = query.HandleWithId();
        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateMovieCommand.CreateMovieInputModel value)
    {
        var command = new CreateMovieCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreateMovieCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Movie created!");
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateMovieCommand.UpdateMovieInputModel value)
    {
        var command = new UpdateMovieCommand(_dbContext, _mapper)
        {
            Id = id,
            Model = value
        };
        
        var validator = new UpdateMovieCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Movie updated!");
    }
}
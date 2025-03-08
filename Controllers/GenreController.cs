using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.GenreOperations.Commands.CreateGenres;
using MovieStore.App.GenreOperations.Queries;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class GenreController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GenreController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var query = new GetGenreQuery(_dbContext, _mapper);
        var result = query.Handle();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var query = new GetGenreQuery(_dbContext, _mapper)
        {
            Id = id
        };
        
        var validator = new GetGenreQueryValidator();
        validator.ValidateAndThrow(query);
        
        var result = query.HandleWithId();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateGenreCommand.CreateGenreInputModel value)
    {
        var command = new CreateGenreCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Genre created!");
    }
}
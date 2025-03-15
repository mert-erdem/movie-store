using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
}
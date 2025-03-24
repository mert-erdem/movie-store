using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.CustomerOperations;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CustomerController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateCustomerCommand.CreateCustomerInputModel value)
    {
        var command = new CreateCustomerCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreateCustomerCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Customer created!");
    }
}
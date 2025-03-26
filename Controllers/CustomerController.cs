using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.CustomerOperations;
using MovieStore.App.CustomerOperations.Commands;
using MovieStore.App.TokenOperations;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class CustomerController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;

    public CustomerController(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _configuration = configuration;
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
    
    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel emailPassword)
    {
        var command = new CreateTokenCommand(_dbContext, _configuration)
        {
            Model = emailPassword
        };
        
        var token = command.Handle();

        return token;
    }
}
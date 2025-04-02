using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.PurchaseOperations;
using MovieStore.App.PurchaseOperations.Queries.GetPurchases;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/[controller]s")]
[Authorize]
public class PurchaseController : ControllerBase
{
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public PurchaseController(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a customer's purchases via customer ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var query = new GetPurchaseQuery(_dbContext, _mapper)
        {
            CustomerId = id
        };

        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreatePurchaseCommand.CreatePurchaseInputModel value)
    {
        var command = new CreatePurchaseCommand(_dbContext, _mapper)
        {
            Model = value
        };
        
        var validator = new CreatePurchaseCommandValidator();
        validator.ValidateAndThrow(command);
        
        command.Handle();
        
        return Ok("Purchase created!");
    }
}
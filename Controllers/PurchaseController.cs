using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.PurchaseOperations;
using MovieStore.DbOperations;

namespace MovieStore.Controllers;

[ApiController]
[Route("api/purchase")]
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
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Middlewares;
using MovieStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase("MovieStoreDb"));
builder.Services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>()!);
builder.Services.AddSingleton<ILoggerService, ConsoleLoggerService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    DataGenerator.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleware>();
app.MapControllers();
app.Run();
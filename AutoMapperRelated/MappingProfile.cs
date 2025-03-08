using AutoMapper;
using MovieStore.App.GenreOperations.Commands.CreateGenres;
using MovieStore.App.GenreOperations.Queries;
using MovieStore.Entities;

namespace MovieStore.AutoMapperRelated;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Genres
        CreateMap<Genre, GetGenreQuery.GenreViewModel>();
        CreateMap<CreateGenreCommand.CreateGenreInputModel, Genre>();
    }
}
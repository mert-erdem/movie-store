using AutoMapper;
using MovieStore.App.GenreOperations.Queries;
using MovieStore.Entities;

namespace MovieStore.AutoMapperRelated;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Genre, GetGenreQuery.GenreViewModel>();
    }
}
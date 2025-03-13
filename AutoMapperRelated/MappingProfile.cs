using AutoMapper;
using MovieStore.App.GenreOperations.Commands.CreateGenres;
using MovieStore.App.GenreOperations.Queries;
using MovieStore.App.MovieOperations.Commands;
using MovieStore.App.MovieOperations.Commands.CreateGenres;
using MovieStore.App.MovieOperations.Commands.UpdateMovies;
using MovieStore.App.MovieOperations.Queries;
using MovieStore.Entities;

namespace MovieStore.AutoMapperRelated;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Movies
        CreateMap<Movie, GetMovieQuery.MovieViewModel>()
            .ForMember(
                x => x.Genre,
                opt => opt
                    .MapFrom(src => src.Genre!.Name))
            .ForMember(
                x => x.Director, 
                opt => opt
                    .MapFrom(src => src.Director!.Name + " " + src.Director!.Surname))
            .ForMember(x => x.Actors, 
                opt => opt
                    .MapFrom(src => src.MovieActors
                        .Select(movieActor => movieActor.Actor.Name + " " + movieActor.Actor.Surname)
                        .ToList()));
        CreateMap<CreateMovieCommand.CreateMovieInputModel, Movie>()
            .ForMember(
                x => x.MovieActors,
                opt => opt
                    .MapFrom(src => src.ActorIdList.Select(id => new MovieActor
                    {
                        ActorId = id
                    }).ToList()));
        CreateMap<UpdateMovieCommand.UpdateMovieInputModel, Movie>()
            .ForMember(
                x => x.MovieActors,
                opt => opt
                    .MapFrom(src => src.ActorIdList.Select(id => new MovieActor
                    {
                        ActorId = id
                    }).ToList()));
        
        // Genres
        CreateMap<Genre, GetGenreQuery.GenreViewModel>();
        CreateMap<CreateGenreCommand.CreateGenreInputModel, Genre>();
    }
}
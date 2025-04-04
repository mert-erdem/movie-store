using AutoMapper;
using MovieStore.App.ActorOperations.Commands.CreateActors;
using MovieStore.App.ActorOperations.Commands.UpdateActors;
using MovieStore.App.ActorOperations.Queries;
using MovieStore.App.CustomerOperations;
using MovieStore.App.DirectorOperations.Commands.CreateDirectors;
using MovieStore.App.DirectorOperations.Commands.UpdateDirectors;
using MovieStore.App.DirectorOperations.Queries;
using MovieStore.App.GenreOperations.Commands.CreateGenres;
using MovieStore.App.GenreOperations.Queries;
using MovieStore.App.MovieOperations.Commands.CreateGenres;
using MovieStore.App.MovieOperations.Commands.UpdateMovies;
using MovieStore.App.MovieOperations.Queries;
using MovieStore.App.PurchaseOperations;
using MovieStore.App.PurchaseOperations.Queries.GetPurchases;
using MovieStore.Entities;

namespace MovieStore.AutoMapperRelated;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMovieMaps();
        CreateActorMaps();
        CreateDirectorMaps();
        CreateGenreMaps();
        CreateCustomerMaps();
        CreatePurchaseMaps();
    }
    
    private void CreateMovieMaps()
    {
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
    }

    private void CreateDirectorMaps()
    {
        CreateMap<Director, GetDirectorQuery.DirectorViewModel>();
        CreateMap<Director, GetDirectorQuery.DetailedDirectorViewModel>();
        CreateMap<CreateDirectorCommand.CreateDirectorInputModel, Director>();
        CreateMap<UpdateDirectorCommand.UpdateDirectorInputModel, Director>();
    }

    private void CreateActorMaps()
    {
        CreateMap<Actor, GetActorQuery.ActorViewModel>()
            .ForMember(
                x => x.Movies,
                opt => opt
                    .MapFrom(src => src.MovieActors
                        .Select(movieActor => movieActor.Movie.Name)
                        .ToList()));

        CreateMap<CreateActorCommand.CreateActorInputModel, Actor>();
        CreateMap<UpdateActorCommand.UpdateActorInputModel, Actor>();
    }
    
    private void CreateGenreMaps()
    {
        CreateMap<Genre, GetGenreQuery.GenreViewModel>();
        CreateMap<CreateGenreCommand.CreateGenreInputModel, Genre>();
    }

    private void CreateCustomerMaps()
    {
        CreateMap<CreateCustomerCommand.CreateCustomerInputModel, Customer>();
    }

    private void CreatePurchaseMaps()
    {
        CreateMap<CreatePurchaseCommand.CreatePurchaseInputModel, Purchase>();
        CreateMap<Purchase, GetPurchaseQuery.PurchaseViewModel>()
            .ForMember(x => x.MovieName, opt => opt
                .MapFrom(src => src.Movie!.Name));
    }
}
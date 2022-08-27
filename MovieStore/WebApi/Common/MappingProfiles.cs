using System.Collections.Generic;
using AutoMapper;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.ActorOperations.Queries.GetActors;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Applications.DirectorOperations.Queries.GetDirectors;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Applications.UserOperations.Queries.GetUserDetail;
using WebApi.Applications.UserOperations.Queries.GetUsers;
using WebApi.Entities;
using static WebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static WebApi.Applications.MovieOperations.Queries.GetMovieDetail.GetMovieDetailQuery;
using static WebApi.Applications.MovieOperations.Queries.GetMovies.GetMoviesQuery;

namespace WebAi.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateMovieModel, Movie>();      
      CreateMap<Movie, MovieDetailViewModel>()
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
        .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.LastName))
        .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => returnActors(src.Actors)));
      CreateMap<Movie, MoviesViewModel>()
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
        .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.LastName))
        .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => returnActors(src.Actors)));

      CreateMap<Genre, GenresViewModel>();
      CreateMap<Genre, GenreDetailViewModel>();
      CreateMap<CreateGenreModel, Genre>();

      CreateMap<Actor, ActorsViewModel>();
      CreateMap<Actor, ActorDetailViewModel>();
      CreateMap<CreateActorModel, Actor>();

      CreateMap<Director, DirectorsViewModel>();
      CreateMap<Director, DirectorDetailViewModel>();
      CreateMap<CreateDirectorModel, Director>();

      CreateMap<CreateUserModel, User>();
      CreateMap<User, UsersViewModel>()
      .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => returnGenres(src.Genres)));
      CreateMap<User, UserDetailViewModel>();
    }
    public List<string> returnActors(List<Actor> actors)
    {
      List<string> actorNames = new List<string>();
      foreach(Actor actor in actors)
      {
        actorNames.Add(actor.Name + " " + actor.LastName);
      }
      return actorNames;
    }

    public List<string> returnGenres(List<Genre> genres)
    {
      List<string> genreNames = new List<string>();
      foreach(Genre genre in genres)
      {
        genreNames.Add(genre.Name);
      }
      return genreNames;
    }
  }
}
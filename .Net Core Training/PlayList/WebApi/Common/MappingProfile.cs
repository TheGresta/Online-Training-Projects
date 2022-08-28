using System.Collections.Generic;
using AutoMapper;
using WebApi.Applications.SingerOperations.Commands.CreateSinger;
using WebApi.Applications.SingerOperations.Queries.GetSingerDetail;
using WebApi.Applications.SingerOperations.Queries.GetSingers;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Applications.UserOperations.Queries.GetUserDetail;
using WebApi.Applications.UserOperations.Queries.GetUsers;
using WebApi.Entities;
using static WebApi.Applications.SongOperations.Commands.CreateSong.CreateSongCommand;
using static WebApi.Applications.SongOperations.Queries.GetSongDetail.GetSongDetailQuery;
using static WebApi.Applications.SongOperations.Queries.GetSongs.GetSongsQuery;

namespace WebAi.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateSongModel, Song>();      
      CreateMap<Song, SongDetailViewModel>()
        .ForMember(dest => dest.Singer, opt => opt.MapFrom(src => src.Singer.Name));
      CreateMap<Song, SongsViewModel>()
        .ForMember(dest => dest.Singer, opt => opt.MapFrom(src => src.Singer.Name));

      CreateMap<Singer, SingersViewModel>();
      CreateMap<Singer, SingerDetailViewModel>();
      CreateMap<CreateSingerModel, Singer>();

      CreateMap<CreateUserModel, User>();
      CreateMap<User, UsersViewModel>();
      CreateMap<User, UserDetailViewModel>();
    }
  }
}
using System.Linq;
using System;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;

namespace WebApi.Applications.SongOperations.Commands.CreateSong
{
  public class CreateSongCommand
  {
    public CreateSongModel Model { get; set; }
    private readonly IPlayListDbContext _context;
    private readonly IMapper _mapper;
    public CreateSongCommand(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Handle()
    {
      var song = _context.Songs.SingleOrDefault(x => x.Title == Model.Title);

      if(song is not null)
        throw new InvalidOperationException("Song Already Exist");

      song = _mapper.Map<Song>(Model);
      _context.Songs.Add(song);
      _context.SaveChanges();
    }

    public class CreateSongModel
    {
      public string Title { get; set; }
      public int SingerId { get; set; }
      public DateTime PublishDate { get; set; }      
    }
  }
}
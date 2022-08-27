using System.Linq;
using System;
using WebApi.DBOperations;

namespace WebApi.Applications.SongOperations.Commands.UpdateSong
{
  public class UpdateSongCommand
  {
    private readonly IPlayListDbContext _context;
    public int SongId { get; set; }
    public UpdateSongModel Model { get; set; }
    public UpdateSongCommand(IPlayListDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var song = _context.Songs.SingleOrDefault(x=> x.Id == SongId);

      if(song is null)
        throw new InvalidOperationException("Song Does Not Exist");
      song.SingerId = Model.SingerId != default ? Model.SingerId : song.SingerId;
      song.Title = Model.Title != default ? Model.Title : song.Title;
      
      _context.SaveChanges();
    }

    public class UpdateSongModel
    {
      public string Title { get; set; }
      public int SingerId { get; set; }
    }
  }
}
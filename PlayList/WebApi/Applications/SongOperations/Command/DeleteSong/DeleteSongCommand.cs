using System.Linq;
using System;
using WebApi.DBOperations;

namespace WebApi.Applications.SongOperations.Commands.DeleteSong
{
  public class DeleteSongCommand
  {
    private readonly IPlayListDbContext _context;
    public int SongId { get; set; }
    public DeleteSongCommand(IPlayListDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var song = _context.Songs.SingleOrDefault(x=> x.Id == SongId);

      if(song is null)
        throw new InvalidOperationException("Book Could Not Be Found");
      
      _context.Songs.Remove(song);
      _context.SaveChanges();
    }
  }
}
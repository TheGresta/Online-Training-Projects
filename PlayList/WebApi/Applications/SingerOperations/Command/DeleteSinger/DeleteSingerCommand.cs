using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.SingerOperations.Commands.DeleteSinger
{
  public class DeleteSingerCommand
  {
    public int SingerId { get; set; }
    private readonly IPlayListDbContext _context;
    public DeleteSingerCommand(IPlayListDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var singer = _context.Singers.SingleOrDefault(x => x.Id == SingerId);
      if(singer is null)
       throw new InvalidOperationException("Singer Does Not Found.");
      var song = _context.Songs.Where(x => x.Singer.Name.ToString() + " " + x.Singer.LastName.ToString() == (singer.Name + " " + singer.LastName));
      if(song is not null)
        throw new InvalidOperationException("A Song in the System has this Singer...");

      _context.Singers.Remove(singer);
      _context.SaveChanges();
    }
  }
}
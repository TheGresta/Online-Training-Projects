using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
  public class DeleteDirectorCommand
  {
    public int DirectorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteDirectorCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);
      if(director is null)
       throw new InvalidOperationException("Director Does Not Found.");
      var movies = _context.Movies.Where(x => x.DirectorId ==  DirectorId);
      if(movies is not null)
        throw new InvalidOperationException("A Movie in the System has this Director!");

      _context.Directors.Remove(director);
      _context.SaveChanges();
    }
  }
}
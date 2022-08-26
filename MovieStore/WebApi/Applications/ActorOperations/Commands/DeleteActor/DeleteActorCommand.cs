using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Commands.DeleteDelete
{
  public class DeleteActorCommand
  {
    public int ActorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteActorCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
      if(actor is null)
       throw new InvalidOperationException("Actor Does Not Found.");
      var movies = _context.Movies.Where(x => x.Actors.Contains(actor));
      if(movies is not null)
        throw new InvalidOperationException("A Movie in the System has this Actor!");

      _context.Actors.Remove(actor);
      _context.SaveChanges();
    }
  }
}
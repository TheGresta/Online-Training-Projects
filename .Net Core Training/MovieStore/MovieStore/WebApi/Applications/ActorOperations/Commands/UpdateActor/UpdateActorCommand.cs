using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
  public class UpdateActorCommand
  {
    public UpdateActorModel Model { get; set; }
    public int ActorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public UpdateActorCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);
      if(actor is null)
       throw new InvalidOperationException("Actor Does Not Found.");

       if(_context.Actors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != ActorId))
         throw new InvalidOperationException("There is already an actor with given name.");

      actor.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? actor.Name : Model.Name;
      actor.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? actor.LastName : Model.LastName;
      _context.SaveChanges();
    }
  }
  public class UpdateActorModel{
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
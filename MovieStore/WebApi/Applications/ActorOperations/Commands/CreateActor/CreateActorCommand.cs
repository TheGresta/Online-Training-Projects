using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.ActorOperations.Commands.CreateActor
{
  public class CreateActorCommand
  {
    public CreateActorModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    public CreateActorCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
  {
    var actor = _context.Actors.SingleOrDefault(x => x.Name == Model.Name && x.LastName == Model.LastName);
      if(actor is not null)
       throw new InvalidOperationException("Actor Already Exist.");

      actor = new Actor();
      actor.Name = Model.Name;
      actor.LastName = Model.LastName;
      
      _context.Actors.Add(actor);
      _context.SaveChanges();
  }
  }  
  public class CreateActorModel{
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
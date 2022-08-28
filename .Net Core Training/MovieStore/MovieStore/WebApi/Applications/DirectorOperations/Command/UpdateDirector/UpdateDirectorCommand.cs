using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
  public class UpdateDirectorCommand
  {
    public UpdateDirectorModel Model { get; set; }
    public int DirectorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public UpdateDirectorCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var director = _context.Actors.SingleOrDefault(x => x.Id == DirectorId);
      if(director is null)
       throw new InvalidOperationException("Director Does Not Found.");

       if(_context.Directors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != DirectorId))
         throw new InvalidOperationException("There is already an director with given name.");

      director.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? director.Name : Model.Name;
      director.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? director.LastName : Model.LastName;
      _context.SaveChanges();
    }
  }
  public class UpdateDirectorModel{
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
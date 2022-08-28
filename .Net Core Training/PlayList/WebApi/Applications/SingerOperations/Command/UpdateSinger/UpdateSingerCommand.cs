using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.SingerOperations.Commands.UpdateSinger
{
  public class UpdateSingerCommand
  {
    public UpdateSingerModel Model { get; set; }
    public int SingerId { get; set; }
    private readonly IPlayListDbContext _context;
    public UpdateSingerCommand(IPlayListDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var singer = _context.Singers.SingleOrDefault(x => x.Id == SingerId);
      if(singer is null)
       throw new InvalidOperationException("Singer Does Not Found.");

       if(_context.Singers.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != SingerId))
         throw new InvalidOperationException("There is already a singer with given name.");

      singer.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? singer.Name : Model.Name;
      singer.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? singer.LastName : Model.LastName;
      singer.IsActive = Model.IsActive;
      singer.BirthDate = Model.BirthDate;
      _context.SaveChanges();
    }
  }
  public class UpdateSingerModel{
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
  }
}
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.SingerOperations.Commands.CreateSinger
{
  public class CreateSingerCommand
  {
    public CreateSingerModel Model { get; set; }
    private readonly IPlayListDbContext _context;
    public CreateSingerCommand(IPlayListDbContext context)
    {
      _context = context;
    }
    public void Handle()
  {
    var singer = _context.Singers.SingleOrDefault(x => x.Name == Model.Name && x.LastName == Model.LastName);
      if(singer is not null)
       throw new InvalidOperationException("Singer Already Exist.");

      singer = new Singer();
      singer.Name = Model.Name;
      singer.LastName = Model.LastName;
      singer.BirthDate = Model.BirthDate;
      _context.Singers.Add(singer);
      _context.SaveChanges();
  }
  }  
  public class CreateSingerModel{
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
  }
}
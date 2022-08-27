using System;
using System.Linq;
using WebApi.DbOperators;
using WebApi.Entities;

namespace WebApi.Applications.SingerOperations.Commands.CreateSinger
{
  public class CreateSingerCommand
  {
    public CreateSingerModel Model { get; set; }
    private readonly IPlayListDbContext _context;
    public CreateSingerModel(IPlayListDbContext context)
    {
      _context = context;
    }
    public void Handle()
  {
    var singer = _context.Singers.SingleOrDefault(x => x.Name == Model.Name);
      if(author is not null)
       throw new InvalidOperationException("Author Already Exist.");

      author = new Author();
      author.Name = Model.Name;
      author.LastName = Model.LastName;
      author.BirthDate = Model.BirthDate;
      _context.Authors.Add(author);
      _context.SaveChanges();
  }
  }  
  public class CreateSingerModel{
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
  }
}
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorCommand
  {
    public UpdateAuthorModel Model { get; set; }
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;
    public UpdateAuthorCommand(IBookStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
      if(author is null)
       throw new InvalidOperationException("Author Does Not Found.");

       if(_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != AuthorId))
         throw new InvalidOperationException("There is already a book type with given name.");

      author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
      author.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? author.LastName : Model.LastName;
      author.IsActive = Model.IsActive;
      author.BirthDate = Model.BirthDate;
      _context.SaveChanges();
    }
  }
  public class UpdateAuthorModel{
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
  }
}
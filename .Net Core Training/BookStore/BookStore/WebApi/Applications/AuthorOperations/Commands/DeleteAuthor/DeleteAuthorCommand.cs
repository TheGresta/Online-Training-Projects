using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
  public class DeleteAuthorCommand
  {
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;
    public DeleteAuthorCommand(IBookStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
      if(author is null)
       throw new InvalidOperationException("Author Does Not Found.");
      var book = _context.Books.Where(x => x.Author.ToString() == (author.Name + " " + author.LastName));
      if(book is not null)
        throw new InvalidOperationException("A Book in the System has this Author...");

      _context.Authors.Remove(author);
      _context.SaveChanges();
    }
  }
}
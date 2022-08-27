using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Commands.DeleteUser
{
  public class DeleteUserCommand
  {
    public int UserId { get; set; }
    private readonly IPlayListDbContext _context;
    public DeleteUserCommand(IPlayListDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var user = _context.Users.SingleOrDefault(x => x.Id == UserId);
      if(user is null)
       throw new InvalidOperationException("User Does Not Found.");

      _context.Users.Remove(user);
      _context.SaveChanges();
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.UserOperations.Commands.UpdateUser
{
  public class UpdateUserCommand
  {
    public UpdateUserModel Model { get; set; }
    public int UserId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public UpdateUserCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var user = _context.Users.SingleOrDefault(x => x.Id == UserId);
      if(user is null)
       throw new InvalidOperationException("User Does Not Found.");

       if(_context.Users.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.LastName.ToLower() == Model.LastName.ToLower() && x.Id != UserId))
         throw new InvalidOperationException("There is already a user with given name.");

      user.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? user.Name : Model.Name;
      user.LastName = string.IsNullOrEmpty(Model.LastName.Trim()) ? user.LastName : Model.LastName;
      user.Password = string.IsNullOrEmpty(Model.Password.Trim()) ? user.Password : Model.Password;
      user.Email = string.IsNullOrEmpty(Model.Email.Trim()) ? user.Email : Model.Email;
      user.FavoriteGenres = Model.FavoriteGenres.Any() ? Model.FavoriteGenres : user.FavoriteGenres;
      _context.SaveChanges();
    }
  }
  public class UpdateUserModel{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Genre> FavoriteGenres { get; set; }
  }
}
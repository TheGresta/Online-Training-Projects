using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
  public class CreateGenreCommand
  {
    public CreateGenreModel Model { get; set; }
    private readonly IMovieStoreDbContext _context;
    public CreateGenreCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
      if(genre is not null)
       throw new InvalidOperationException("Movie Type Already Exist.");

      genre = new Genre();
      genre.Name = Model.Name;
      _context.Genres.Add(genre);
      _context.SaveChanges();
    }
  }

  public class CreateGenreModel{
    public string Name { get; set; }
  }
}
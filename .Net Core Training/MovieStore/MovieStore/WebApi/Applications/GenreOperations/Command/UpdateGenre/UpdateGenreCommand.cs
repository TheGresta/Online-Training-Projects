using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreCommand
  {
    public UpdateGenreModel Model { get; set; }
    public int GenreId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public UpdateGenreCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
      if(genre is null)
       throw new InvalidOperationException("Book Type Does Not Found.");

       if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
         throw new InvalidOperationException("There is already a book type with given name.");

      genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
      genre.IsActive = Model.IsActive;
      _context.SaveChanges();
    }
  }
  public class UpdateGenreModel{
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
  }
}
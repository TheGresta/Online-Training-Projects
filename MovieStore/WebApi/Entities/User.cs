using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public List<Genre> FavoriteGenres { get; set; }
    public Genre Genre { get; set; }
    public List<Movie> PurcgasedMovies { get; set; }
    public Movie Movie { get; set; }
  }
}
using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Movies
  {
    public static void AddMovies(this MovieStoreDbContext context)
    {
      context.Movies.AddRange(
        new Movie{
          Name = "The Godfater", 
          GenreId = 6, DirectorId = 1, Price = 30,
          PublishDate = new DateTime(1972), 
          Actors = new List<Actor>()},
        new Movie{
          Name = "Citizen Kane", 
          GenreId = 3, DirectorId = 2, Price = 20,
          PublishDate = new DateTime(1941), 
          Actors = new List<Actor>()},
        new Movie{
          Name = "La Dolce Vita", 
          GenreId = 7, DirectorId = 3, Price = 10,
          PublishDate = new DateTime(1960), 
          Actors = new List<Actor>()},
        new Movie{
          Name = "Seven Samurai", 
          GenreId = 1, DirectorId = 4, Price = 40,
          PublishDate = new DateTime(1954), 
          Actors = new List<Actor>()},
        new Movie{
          Name = "There Will Be Blood", 
          GenreId = 3, DirectorId = 5, Price = 25,
          PublishDate = new DateTime(2007), 
          Actors = new List<Actor>()},
        new Movie{
          Name = "Singing in the Rain", 
          GenreId = 5, DirectorId = 6, Price = 15,
          PublishDate = new DateTime(1952), 
          Actors = new List<Actor>()});
    }
  }
}
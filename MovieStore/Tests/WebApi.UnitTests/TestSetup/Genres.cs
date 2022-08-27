using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Genres
  {
    public static void AddGenres(this MovieStoreDbContext context)
    {
      context.Genres.AddRange(
          new Genre{Name = "Action"},
          new Genre{Name = "Comedy"},
          new Genre{Name = "Drama"},
          new Genre{Name = "Fantasy"},
          new Genre{Name = "Horror"},
          new Genre{Name = "Mystery"},
          new Genre{Name = "Romance"});
    }
  }
}
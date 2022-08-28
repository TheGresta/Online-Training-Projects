using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Directors
  {
    public static void AddDirectors(this MovieStoreDbContext context)
    {
      context.Directors.AddRange(
          new Director{Name = "Alfred", LastName = "Hitchcock"},
          new Director{Name = "Orson", LastName = "Welles"},
          new Director{Name = "John", LastName = "Ford"},
          new Director{Name = "Howard", LastName = "Hawks"},
          new Director{Name = "Martin", LastName = "Scorsese"},
          new Director{ Name = "Akira", LastName = "Kurosawa"});
    }
  }
}
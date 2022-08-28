using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Actors
  {
    public static void AddActors(this MovieStoreDbContext context)
    {
      context.Actors.AddRange(
          new Actor{Name = "Robert", LastName = "DeNiro"},
          new Actor{Name = "Jack", LastName = "Nicholson"},
          new Actor{Name = "Marlon", LastName = "Brando"},
          new Actor{Name = "Denzel", LastName = "Washington"},
          new Actor{Name = "Katharine", LastName = "Hepburn"},
          new Actor{Name = "Humphrey", LastName = "Bogart"},
          new Actor{Name = "Meryl", LastName = "Streep"},
          new Actor{Name = "Daniel", LastName = "DayLewis"},
          new Actor{Name = "Sidney", LastName = "Poitier"},
          new Actor{Name = "Clark", LastName = "Geble"},
          new Actor{Name = "Ingrid", LastName = "Bergman"},
          new Actor{Name = "Tom", LastName = "Hanks"},
          new Actor{Name = "Elizabeth", LastName = "Taylor"},
          new Actor{ Name = "Bette", LastName = "Davis"});
    }
  }
}
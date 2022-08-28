using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Users
  {
    public static void AddUsers(this MovieStoreDbContext context)
    {
      context.Users.AddRange(
          new User{
            Name = "Aslı",
            LastName = "Yılmaz",
            Email = "aslı@hotmail.com",
            Password = "123456",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()},
          new User{
            Name = "Enver",
            LastName = "Canlı",
            Email = "enver@hotmail.com",
            Password = "123321",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()},
          new User{
            Name = "Kamil",
            LastName = "Kosucu",
            Email = "kamil@hotmail.com",
            Password = "111222",
            Movies = new List<Movie>(),
            Genres = new List<Genre>()});
    }
  }
}
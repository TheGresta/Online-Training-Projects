using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new PlayListDbContext(serviceProvider.GetRequiredService<DbContextOptions<PlayListDbContext>>()))
      {
        if (context.Songs.Any())
          return;

        context.Singers.AddRange(
          new Singer{Name = "Taylor", LastName = "Swift", BirthDate = new DateTime(1989, 12, 13)},
          new Singer{Name = "Selena", LastName = "Gomez", BirthDate = new DateTime(1992, 07, 22)},
          new Singer{Name = "Ariana", LastName = "Grande", BirthDate = new DateTime(1993, 06, 26)},
          new Singer{Name = "Ed", LastName = "Sheeran", BirthDate = new DateTime(1991, 09, 17)},
          new Singer{Name = "Dua", LastName = "Lipa", BirthDate = new DateTime(1995, 08, 22)});

        context.Songs.AddRange(
          new Song{Title = "Neo Lie", SingerId = 5},
          new Song{Title = "One Kiss", SingerId = 5},
          new Song{Title = "Shaper of You", SingerId = 4},
          new Song{Title = "Perfect", SingerId = 4},
          new Song{Title = "Side to Side", SingerId = 3},
          new Song{Title = "God is a woman", SingerId = 3},
          new Song{Title = "Ice Cream", SingerId = 2},
          new Song{Title = "Same Old Love", SingerId = 2},
          new Song{Title = "Black Space", SingerId = 1},
          new Song{Title = "This Love", SingerId = 1});  
        
        context.Users.AddRange(
          new User{
            Name = "Aslı",
            LastName = "Yılmaz",
            Email = "aslı@hotmail.com",
            Password = "123456"},
          new User{
            Name = "Enver",
            LastName = "Canlı",
            Email = "enver@hotmail.com",
            Password = "123321"},
          new User{
            Name = "Kamil",
            LastName = "Kosucu",
            Email = "kamil@hotmail.com",
            Password = "111222"}); 
        context.SaveChanges(); 
      }
    }
  }
}
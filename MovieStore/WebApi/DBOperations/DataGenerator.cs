using System;
using System.Collections.Generic;
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
      using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
      {
        if (context.Movies.Any())
          return;

        context.Genres.AddRange(
          new Genre{Name = "Action"},
          new Genre{Name = "Comedy"},
          new Genre{Name = "Drama"},
          new Genre{Name = "Fantasy"},
          new Genre{Name = "Horror"},
          new Genre{Name = "Mystery"},
          new Genre{Name = "Romance"});

        context.Directors.AddRange(
          new Director{Name = "Alfred", LastName = "Hitchcock"},
          new Director{Name = "Orson", LastName = "Welles"},
          new Director{Name = "John", LastName = "Ford"},
          new Director{Name = "Howard", LastName = "Hawks"},
          new Director{Name = "Martin", LastName = "Scorsese"},
          new Director{ Name = "Akira", LastName = "Kurosawa"});

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

        context.Movies.AddRange(
          new Movie{
            Name = "The Godfater", 
            GenreId = 6, DirectorId = 1, Price = 30,
            PublishDate = new DateTime(1972), 
            Actors = new List<Actor>(){
              new Actor{Name = "Robert", LastName = "DeNiro"},
              new Actor{Name = "Jack", LastName = "Nicholson"},
              new Actor{Name = "Marlon", LastName = "Brando"},
              new Actor{Name = "Denzel", LastName = "Washington"},
              new Actor{Name = "Katharine", LastName = "Hepburn"},
              new Actor{Name = "Elizabeth", LastName = "Taylor"}}},
          new Movie{
            Name = "Citizen Kane", 
            GenreId = 3, DirectorId = 2, Price = 20,
            PublishDate = new DateTime(1941), 
            Actors = new List<Actor>(){
              new Actor{Name = "Marlon", LastName = "Brando"},
              new Actor{Name = "Denzel", LastName = "Washington"},
              new Actor{Name = "Katharine", LastName = "Hepburn"},
              new Actor{Name = "Humphrey", LastName = "Bogart"},
              new Actor{Name = "Meryl", LastName = "Streep"}}},
          new Movie{
            Name = "La Dolce Vita", 
            GenreId = 7, DirectorId = 3, Price = 10,
            PublishDate = new DateTime(1960), 
            Actors = new List<Actor>(){
              new Actor{Name = "Katharine", LastName = "Hepburn"},
              new Actor{Name = "Humphrey", LastName = "Bogart"},
              new Actor{Name = "Meryl", LastName = "Streep"},
              new Actor{Name = "Daniel", LastName = "DayLewis"},
              new Actor{Name = "Sidney", LastName = "Poitier"},
              new Actor{Name = "Clark", LastName = "Geble"},
              new Actor{Name = "Ingrid", LastName = "Bergman"}}},
          new Movie{
            Name = "Seven Samurai", 
            GenreId = 1, DirectorId = 4, Price = 40,
            PublishDate = new DateTime(1954), 
            Actors = new List<Actor>(){
              new Actor{Name = "Meryl", LastName = "Streep"},
              new Actor{Name = "Daniel", LastName = "DayLewis"},
              new Actor{Name = "Sidney", LastName = "Poitier"},
              new Actor{Name = "Clark", LastName = "Geble"},
              new Actor{Name = "Ingrid", LastName = "Bergman"},
              new Actor{Name = "Tom", LastName = "Hanks"},
              new Actor{Name = "Elizabeth", LastName = "Taylor"},
              new Actor{ Name = "Bette", LastName = "Davis"}}},
          new Movie{
            Name = "There Will Be Blood", 
            GenreId = 3, DirectorId = 5, Price = 25,
            PublishDate = new DateTime(2007), 
            Actors = new List<Actor>(){
              new Actor{Name = "Tom", LastName = "Hanks"},
              new Actor{Name = "Elizabeth", LastName = "Taylor"},
              new Actor{ Name = "Bette", LastName = "Davis"},
              new Actor{Name = "Marlon", LastName = "Brando"},
              new Actor{Name = "Denzel", LastName = "Washington"},
              new Actor{Name = "Katharine", LastName = "Hepburn"}}},
          new Movie{
            Name = "Singing in the Rain", 
            GenreId = 5, DirectorId = 6, Price = 15,
            PublishDate = new DateTime(1952), 
            Actors = new List<Actor>(){
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
              new Actor{ Name = "Bette", LastName = "Davis"}}}    
        );

        context.Users.AddRange(
          new User{
            Name = "Aslı",
            LastName = "Yılmaz",
            Email = "aslı@hotmail.com",
            Password = "123456",
            PurcgasedMovies = new List<Movie>(),
            FavoriteGenres = new List<Genre>(){
              new Genre{Name = "Action"},
              new Genre{Name = "Comedy"},
              new Genre{Name = "Drama"},
              new Genre{Name = "Fantasy"},
              new Genre{Name = "Horror"},
              new Genre{Name = "Mystery"},
              new Genre{Name = "Romance"}}},
          new User{
            Name = "Enver",
            LastName = "Canlı",
            Email = "enver@hotmail.com",
            Password = "123321",
            PurcgasedMovies = new List<Movie>(),
            FavoriteGenres = new List<Genre>(){
              new Genre{Name = "Action"},
              new Genre{Name = "Comedy"}}},
          new User{
            Name = "Kamil",
            LastName = "Kosucu",
            Email = "kamil@hotmail.com",
            Password = "111222",
            PurcgasedMovies = new List<Movie>(),
            FavoriteGenres = new List<Genre>(){
              new Genre{Name = "Action"}}}
        );
                  
        context.SaveChanges(); 
      }
    }
  }
}
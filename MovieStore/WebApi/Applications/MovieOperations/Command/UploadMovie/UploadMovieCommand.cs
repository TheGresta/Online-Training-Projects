using System.Linq;
using System;
using WebApi.DBOperations;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
  public class UpdateMovieCommand
  {
    private readonly IMovieStoreDbContext _context;
    public int MovieId { get; set; }
    public UpdateMovieModel Model { get; set; }
    public UpdateMovieCommand(IMovieStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var movie = _context.Movies.SingleOrDefault(x=> x.Id == MovieId);

      if(movie is null)
        throw new InvalidOperationException("Movie Does Not Exist!");
      movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
      movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
      movie.Name = Model.Name != default ? Model.Name : movie.Name;
      movie.Price = Model.Price != default ? Model.Price : movie.Price;
      movie.PublishDate = Model.PublishDate != default ? Model.PublishDate : movie.PublishDate;
      movie.Actors = Model.Actors != default ? Model.Actors : movie.Actors;
      _context.SaveChanges();
    }

    public class UpdateMovieModel
    {
      public string Name { get; set; }
      public int Price { get; set; }   
      public  DateTime PublishDate { get; set; }
      public int GenreId { get; set; }
      public int DirectorId { get; set; }
      public List<Actor> Actors { get; set; } 
    }
  }
}
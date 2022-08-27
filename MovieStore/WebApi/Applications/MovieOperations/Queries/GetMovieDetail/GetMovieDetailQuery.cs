using System.Linq;
using System;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
  public class GetMovieDetailQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public int MovieId { get; set; }
    public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public MovieDetailViewModel Handle()
    {
      var movie = _context.Movies.Include(x => x.Genre).Include(x => x.Director).Include(x => x.Actors).Where(movie => movie.Id == MovieId).SingleOrDefault();
      if(movie is null)
        throw new InvalidOperationException("Movie Could Not Be Found");
      MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
      return vm;
    }

    public class MovieDetailViewModel
    {
      public string Name { get; set; }
      public int Price { get; set; }   
      public  DateTime PublishDate { get; set; }
      public string Genre { get; set; }
      public string Director { get; set; }
      public List<string> Actors { get; set; }     
    }
  }
}
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Applications.MovieOperations.Queries.GetMovies
{
  public class GetMoviesQuery
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public List<MoviesViewModel> Handle()
    {
      var movieList = _context.Movies.Include(x => x.Genre).Include(x => x.Director).Include(x => x.Actors).OrderBy(x => x.Id).ToList<Movie>();
      List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
      return vm;
    }

    public class MoviesViewModel
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
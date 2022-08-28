using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.UserOperations.Queries.GetUserDetail
{
  public class GetUserDetailQuery
  {
    public int UserId;
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetUserDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public UserDetailViewModel Handle()
    {
      var user = _context.Users.Include(x => x.Genres).Include(x => x.Movies).SingleOrDefault(x => x.Id == UserId);
      if(user is null)
        throw new InvalidOperationException("User Does Not Exist!");
      return _mapper.Map<UserDetailViewModel>(user);
    }
  }

  public class UserDetailViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Genre> FavoriteGenres { get; set; }
    public List<Movie> PurcgasedMovies { get; set; }
  }
}
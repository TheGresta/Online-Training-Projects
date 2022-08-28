using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.UserOperations.Queries.GetUsers
{
  public class GetUsersQuery
  {
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetUsersQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<UsersViewModel> Handle()
    {
      var users = _context.Users.Include(x => x.Genres).Include(x => x.Movies).OrderBy(x => x.Id);
      List<UsersViewModel> returnObj = _mapper.Map<List<UsersViewModel>>(users);
      return returnObj;
    }
  }

  public class UsersViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }    
    public List<string> Movies { get; set; }
    public List<string> Genres { get; set; }
  }
}
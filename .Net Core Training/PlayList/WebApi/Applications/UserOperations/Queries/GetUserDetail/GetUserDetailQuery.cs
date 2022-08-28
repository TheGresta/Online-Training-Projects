using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.UserOperations.Queries.GetUserDetail
{
  public class GetUserDetailQuery
  {
    public int UserId;
    public readonly IPlayListDbContext _context;
    public readonly IMapper _mapper;
    public GetUserDetailQuery(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public UserDetailViewModel Handle()
    {
      var user = _context.Users.SingleOrDefault(x => x.Id == UserId);
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
  }
}
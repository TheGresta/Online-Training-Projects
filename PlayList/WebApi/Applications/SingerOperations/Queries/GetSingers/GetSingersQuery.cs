using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.SingerOperations.Queries.GetSingers
{
  public class GetSingersQuery
  {
    public readonly IPlayListDbContext _context;
    public readonly IMapper _mapper;
    public GetSingersQuery(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<SingersViewModel> Handle()
    {
      var singers = _context.Singers.Where(x => x.IsActive).OrderBy(x => x.Id);
      List<SingersViewModel> returnObj = _mapper.Map<List<SingersViewModel>>(singers);
      return returnObj;
    }
  }

  public class SingersViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
  }
}
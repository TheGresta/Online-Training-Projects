using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectors
{
  public class GetDirectorsQuery
  {
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<DirectorsViewModel> Handle()
    {
      var directors = _context.Directors.OrderBy(x => x.Id);
      List<DirectorsViewModel> returnObj = _mapper.Map<List<DirectorsViewModel>>(directors);
      return returnObj;
    }
  }

  public class DirectorsViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
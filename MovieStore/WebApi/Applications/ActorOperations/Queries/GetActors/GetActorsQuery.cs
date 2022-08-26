using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.ActorOperations.Queries.GetActors
{
  public class GetActorsQuery
  {
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<ActorsViewModel> Handle()
    {
      var actors = _context.Actors.OrderBy(x => x.Id);
      List<ActorsViewModel> returnObj = _mapper.Map<List<ActorsViewModel>>(actors);
      return returnObj;
    }
  }

  public class ActorsViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
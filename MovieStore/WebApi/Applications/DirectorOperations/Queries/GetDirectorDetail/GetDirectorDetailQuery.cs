using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail
{
  public class GetDirectorDetailQuery
  {
    public int DirectorId;
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public DirectorDetailViewModel Handle()
    {
      var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);
      if(director is null)
        throw new InvalidOperationException("Director Does Not Exist!");
      return _mapper.Map<DirectorDetailViewModel>(director);
    }
  }

  public class DirectorDetailViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
  }
}
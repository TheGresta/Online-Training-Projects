using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.SingerOperations.Queries.GetSingerDetail
{
  public class GetSingerDetailQuery
  {
    public int SingerId;
    public readonly IPlayListDbContext _context;
    public readonly IMapper _mapper;
    public GetSingerDetailQuery(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public SingerDetailViewModel Handle()
    {
      var singer = _context.Singers.SingleOrDefault(x => x.IsActive && x.Id == SingerId);
      if(singer is null)
        throw new InvalidOperationException("Singer Does Not Exist!");
      return _mapper.Map<SingerDetailViewModel>(singer);
    }
  }

  public class SingerDetailViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
  }
}
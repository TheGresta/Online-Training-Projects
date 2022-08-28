using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
  public class GetAuthorDetailQuery
  {
    public int AuthorId;
    public readonly IBookStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public AuthorDetailViewModel Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.IsActive && x.Id == AuthorId);
      if(author is null)
        throw new InvalidOperationException("Author Does Not Exist!");
      return _mapper.Map<AuthorDetailViewModel>(author);
    }
  }

  public class AuthorDetailViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public  DateTime BirthDate { get; set; }
  }
}
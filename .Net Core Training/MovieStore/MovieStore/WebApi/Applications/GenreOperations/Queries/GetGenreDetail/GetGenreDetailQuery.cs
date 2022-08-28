using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenreDetail
{
  public class GetGenreDetailQuery
  {
    public int GenreId;
    public readonly IMovieStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public GenreDetailViewModel Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
      if(genre is null)
        throw new InvalidOperationException("Kitap Türü Bulunamadı!");
      return _mapper.Map<GenreDetailViewModel>(genre);
    }
  }

  public class GenreDetailViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
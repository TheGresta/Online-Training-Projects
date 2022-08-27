using System.Linq;
using System;
using AutoMapper;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.SongOperations.Queries.GetSongDetail
{
  public class GetSongDetailQuery
  {
    private readonly IPlayListDbContext _context;
    private readonly IMapper _mapper;
    public int SongId { get; set; }
    public GetSongDetailQuery(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public SongDetailViewModel Handle()
    {
      var song = _context.Songs.Where(book => book.Id == SongId).SingleOrDefault();
      if(song is null)
        throw new InvalidOperationException("Song Could Not Be Found");
      SongDetailViewModel vm = _mapper.Map<SongDetailViewModel>(song);
      return vm;
    }

    public class SongDetailViewModel
    {
      public string Title { get; set; }
      public string Singer { get; set; }   
    }
  }
}
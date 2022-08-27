using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.SongOperations.Queries.GetSongs
{
  public class GetSongsQuery
  {
    private readonly IPlayListDbContext _context;
    private readonly IMapper _mapper;
    public GetSongsQuery(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public List<SongsViewModel> Handle()
    {
      var songList = _context.Songs.OrderBy(x => x.Id).ToList<Song>();
      List<SongsViewModel> vm = _mapper.Map<List<SongsViewModel>>(songList);
      return vm;
    }

    public class SongsViewModel
    {
      public string Title { get; set; }
      public string PublishDate { get; set; }
      public string Singer { get; set; }
    }
  }
}
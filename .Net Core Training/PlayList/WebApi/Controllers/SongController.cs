using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.SongOperations.Commands.CreateSong;
using WebApi.Applications.SongOperations.Commands.DeleteSong;
using WebApi.Applications.SongOperations.Commands.UpdateSong;
using WebApi.Applications.SongOperations.Queries.GetSongDetail;
using WebApi.Applications.SongOperations.Queries.GetSongs;
using WebApi.DBOperations;
using static WebApi.Applications.SongOperations.Commands.CreateSong.CreateSongCommand;
using static WebApi.Applications.SongOperations.Commands.UpdateSong.UpdateSongCommand;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class SongController : ControllerBase
  {
     private readonly IPlayListDbContext _context; 
     private readonly IMapper _mapper;
    public SongController(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetActors()
    {
      GetSongsQuery query = new GetSongsQuery(_context, _mapper);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetSongDetail(int id)
    {
      GetSongDetailQuery query = new GetSongDetailQuery(_context, _mapper);
      query.SongId = id;
      GetSongDetailQueryValidator validator = new GetSongDetailQueryValidator();
      validator.ValidateAndThrow(query);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddSong([FromBody] CreateSongModel newSong)
    {
      CreateSongCommand command = new CreateSongCommand(_context, _mapper);
      command.Model = newSong;

      CreateSongCommandValidator validator = new CreateSongCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSong(int id, [FromBody] UpdateSongModel newSong)
    {
      UpdateSongCommand command = new UpdateSongCommand(_context);      
      command.Model = newSong;
      command.SongId = id;

      UpdateSongCommandValidator validator = new UpdateSongCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSong(int id)
    {
      DeleteSongCommand command = new DeleteSongCommand(_context);
      command.SongId = id;

      DeleteSongCommandValidator validator = new DeleteSongCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}
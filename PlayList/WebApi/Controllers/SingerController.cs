using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.SingerOperations.Commands.CreateSinger;
using WebApi.Applications.SingerOperations.Commands.DeleteSinger;
using WebApi.Applications.SingerOperations.Commands.UpdateSinger;
using WebApi.Applications.SingerOperations.Queries.GetSingerDetail;
using WebApi.Applications.SingerOperations.Queries.GetSingers;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public class SingerController : ControllerBase
  {
     private readonly IPlayListDbContext _context; 
     private readonly IMapper _mapper;
    public SingerController(IPlayListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetSingers()
    {
      GetSingersQuery query = new GetSingersQuery(_context, _mapper);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetSingerDetail(int id)
    {
      GetSingerDetailQuery query = new GetSingerDetailQuery(_context, _mapper);
      query.SingerId = id;
      GetSingerDetailQueryValidator validator = new GetSingerDetailQueryValidator();
      validator.ValidateAndThrow(query);
      var obj = query.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddSinger([FromBody] CreateSingerModel newSinger)
    {
      CreateSingerCommand command = new CreateSingerCommand(_context);
      command.Model = newSinger;

      CreateSingerCommandValidator validator = new CreateSingerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSinger(int id, [FromBody] UpdateSingerModel newSinger)
    {
      UpdateSingerCommand command = new UpdateSingerCommand(_context);      
      command.Model = newSinger;
      command.SingerId = id;

      UpdateSingerCommandValidator validator = new UpdateSingerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSinger(int id)
    {
      DeleteSingerCommand command = new DeleteSingerCommand(_context);
      command.SingerId = id;

      DeleteSingerCommandValidator validator = new DeleteSingerCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}
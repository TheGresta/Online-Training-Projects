using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.Applications.ActorOperations.Commands.DeleteActor;
using WebApi.Applications.ActorOperations.Commands.UpdateActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.ActorOperations.Queries.GetActors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[Controller]s")]
  public class ActorController : ControllerBase
  {
     private readonly MovieStoreDbContext _context; 
     private readonly IMapper _mapper;
    public ActorController(MovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetActors()
    {
      GetActorsQuery actors = new GetActorsQuery(_context, _mapper);
      var obj = actors.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetActorDetail(int id)
    {
      GetActorDetailQuery actor = new GetActorDetailQuery(_context, _mapper);
      actor.ActorId = id;
      GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
      validator.ValidateAndThrow(actor);
      var obj = actor.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddActor([FromBody] CreateActorModel newActor)
    {
      CreateActorCommand command = new CreateActorCommand(_context);
      command.Model = newActor;

      CreateActorCommandValidator validator = new CreateActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel newActor)
    {
      UpdateActorCommand command = new UpdateActorCommand(_context);      
      command.Model = newActor;
      command.ActorId = id;

      UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
      DeleteActorCommand command = new DeleteActorCommand(_context);
      command.ActorId = id;

      DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}
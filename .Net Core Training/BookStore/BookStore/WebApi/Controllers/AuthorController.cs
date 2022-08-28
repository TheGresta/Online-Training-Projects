using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("[controller]s")]
  public class AuthorController : ControllerBase
  {
     private readonly BookStoreDbContext _context; 
     private readonly IMapper _mapper;
    public AuthorController(BookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetAuthors()
    {
      GetAuthorsQuery authors = new GetAuthorsQuery(_context, _mapper);
      var obj = authors.Handle();
      return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetAuthorDetail(int id)
    {
      GetAuthorDetailQuery author = new GetAuthorDetailQuery(_context, _mapper);
      author.AuthorId = id;
      GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
      validator.ValidateAndThrow(author);
      var obj = author.Handle();
      return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
    {
      CreateAuthorCommand command = new CreateAuthorCommand(_context);
      command.Model = newAuthor;

      CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel newAuthor)
    {
      UpdateAuthorCommand command = new UpdateAuthorCommand(_context);      
      command.Model = newAuthor;
      command.AuthorId = id;

      UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
      DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
      command.AuthorId = id;

      DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();
      return Ok();
    }
  }
}
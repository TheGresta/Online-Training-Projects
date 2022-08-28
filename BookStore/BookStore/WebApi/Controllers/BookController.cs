using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using WebApi.DBOperations;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using static WebApi.Applications.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using static WebApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using static WebApi.Applications.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.Applications.BookOperations.Commands.UpdateBook;
using WebApi.Applications.BookOperations.Commands.DeleteBook;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]  
  [Route("[Controller]s")]
  public class BookController : ControllerBase  
  {
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public BookController(IBookStoreDbContext context , IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
      GetBooksQuery query = new GetBooksQuery(_context, _mapper);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    { 
      BookDetailViewModel result; 
      
      GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
      query.BookId = id;
      GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
      validator.ValidateAndThrow(query);
      result = query.Handle();
      
      return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
      CreateBookCommand command = new CreateBookCommand(_context, _mapper);
      command.Model = newBook;
      CreateBookCommandValidator validator = new CreateBookCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle(); 
      return Ok();      
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
    {      
      UpdateBookCommand command = new UpdateBookCommand(_context);
      command.BookId = id; 
      command.Model = updatedBook; 

      UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();
      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {      
      DeleteBookCommand command = new DeleteBookCommand(_context);
      command.BookId = id;
      DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();      
      return Ok();
    }
  }
}
using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
  public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
      _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {      
      var book = new Book(){Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, AuthorId = 1};

      _context.Books.Add(book);
      _context.SaveChanges();

      CreateBookCommand command = new CreateBookCommand(_context, _mapper);
      command.Model = new CreateBookModel(){Title = book.Title};

      FluentActions
        .Invoking(()=> command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book Already Exist");
    }

    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
    {
      CreateBookCommand command = new CreateBookCommand(_context, _mapper);
      CreateBookModel model = new CreateBookModel(){Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1, AuthorId = 1};
      command.Model = model;

      FluentActions.Invoking(() => command.Handle()).Invoke();

      var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
      book.Should().NotBeNull();
      book.PageCount.Should().Be(model.PageCount);
      book.PublishDate.Should().Be(model.PublishDate);
      book.GenreId.Should().Be(model.GenreId);
      book.AuthorId.Should().Be(model.AuthorId);
    }
  }
}
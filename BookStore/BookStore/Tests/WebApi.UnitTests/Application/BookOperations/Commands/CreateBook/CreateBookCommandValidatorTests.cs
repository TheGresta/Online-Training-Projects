using System;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using Xunit;
using static WebApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
  public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
  {    
    [Theory]
    [InlineData("Lord Of The Rings", 0, 0, 0)]
    [InlineData("Lord Of The Rings", 0, 1, 0)]
    [InlineData("Lord Of The Rings", 1000, 1, 0)]
    [InlineData("Lord Of The Rings", 0, 1, 1)]
    [InlineData("", 0, 0, 0)]
    [InlineData("", 1, 0, 0)]
    [InlineData("", 0, 1, 0)]
    [InlineData("", 0, 0, 1)]
    [InlineData("", 1000, 1, 1)]
    [InlineData("Lor", 1000, 1, 1)]
    [InlineData("Lor", 0, 0, 0)]
    [InlineData("Lord", 0, 1, 0)]
    [InlineData("Lord", 1000, 0, 1)]
    public void WhenInvalidInpusAreGiven_Validator_ShouldBeReturnErrors(string title, int pagecount, int genreId, int authorId)
    {
      CreateBookCommand command = new CreateBookCommand(null, null);
      command.Model = new CreateBookModel(){
        Title = title, 
        PageCount = pagecount, 
        PublishDate = DateTime.Now.Date.AddYears(-1), 
        GenreId = genreId,
        AuthorId = authorId
      };

      CreateBookCommandValidator validator = new CreateBookCommandValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);  
    }

    [Fact]
    public void  WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
      CreateBookCommand command = new CreateBookCommand(null, null);
      command.Model = new CreateBookModel(){
        Title = "Lord Of The Rings", 
        PageCount = 1100, 
        PublishDate = DateTime.Now.Date, 
        GenreId = 1,
        AuthorId = 1
      };

      CreateBookCommandValidator validator = new CreateBookCommandValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public void  WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
      CreateBookCommand command = new CreateBookCommand(null, null);
      command.Model = new CreateBookModel(){
        Title = "Lord Of The Rings", 
        PageCount = 1100, 
        PublishDate = DateTime.Now.Date.AddYears(-2), 
        GenreId = 1,
        AuthorId = 1
      };

      CreateBookCommandValidator validator = new CreateBookCommandValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().Be(0);
    }
  }
}

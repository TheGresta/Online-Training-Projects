using FluentValidation;

namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
  public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
  {
    public DeleteBookCommandValidator()
    {
      RuleFor(command => command.BookId).GreaterThan(0);
    }
  }
}
using System;
using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
  {
    public CreateAuthorCommandValidator()
    {
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.BirthDate.Date).
      NotEmpty().LessThan(DateTime.Now.Date);
    } 
  }
}
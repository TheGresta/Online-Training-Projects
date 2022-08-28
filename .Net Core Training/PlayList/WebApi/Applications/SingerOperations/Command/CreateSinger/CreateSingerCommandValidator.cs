using System;
using FluentValidation;

namespace WebApi.Applications.SingerOperations.Commands.CreateSinger
{
  public class CreateSingerCommandValidator : AbstractValidator<CreateSingerCommand>
  {
    public CreateSingerCommandValidator()
    {
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.BirthDate.Date).
      NotEmpty().LessThan(DateTime.Now.Date);
    } 
  }
}
using System;
using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.CreateMovie
{
  public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
  {
    public CreateMovieCommandValidator()
    {
      RuleFor(command => command.Model.GenreId).GreaterThan(0);
      RuleFor(command => command.Model.DirectorId).GreaterThan(0);
      RuleFor(command => command.Model.PublishDate.Date).
      NotEmpty().LessThan(DateTime.Now.Date);
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
      RuleFor(command => command.Model.Price).GreaterThan(0);
      RuleFor(command => command.Model.Actors).NotEmpty();
    }
  }
}

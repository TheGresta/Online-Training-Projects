using System;
using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie
{
  public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
  {
    public UpdateMovieCommandValidator()
    {
      RuleFor(command => command.MovieId).GreaterThan(0);
      RuleFor(command => command.Model.GenreId).GreaterThan(0);
      RuleFor(command => command.Model.DirectorId).GreaterThan(0);
      RuleFor(command => command.Model.Price).GreaterThan(10);
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
      RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
      RuleFor(command => command.Model.ActorIdList).NotEmpty();
    }
  }
}
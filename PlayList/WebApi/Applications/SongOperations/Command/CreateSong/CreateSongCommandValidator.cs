using System;
using FluentValidation;

namespace WebApi.Applications.SongOperations.Commands.CreateSong
{
  public class CreateSongCommandValidator : AbstractValidator<CreateSongCommand>
  {
    public CreateSongCommandValidator()
    {
      RuleFor(command => command.Model.SingerId).GreaterThan(0);
      RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
    }
  }
}

using FluentValidation;

namespace WebApi.Applications.SongOperations.Commands.UpdateSong
{
  public class UpdateSongCommandValidator : AbstractValidator<UpdateSongCommand>
  {
    public UpdateSongCommandValidator()
    {
      RuleFor(command => command.SongId).GreaterThan(0);
      RuleFor(command => command.Model.SingerId).GreaterThan(0);
      RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
    }
  }
}
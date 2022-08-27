using FluentValidation;

namespace WebApi.Applications.SongOperations.Commands.DeleteSong
{
  public class DeleteSongCommandValidator : AbstractValidator<DeleteSongCommand>
  {
    public DeleteSongCommandValidator()
    {
      RuleFor(command => command.SongId).GreaterThan(0);
    }
  }
}
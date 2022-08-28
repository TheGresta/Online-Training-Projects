using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
  public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
  {
    public DeleteDirectorCommandValidator()
    {
      RuleFor(command => command.DirectorId).GreaterThan(0);
    } 
  }
}
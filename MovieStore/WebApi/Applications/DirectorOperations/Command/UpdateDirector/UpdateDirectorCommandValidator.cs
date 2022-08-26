using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
  public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
  {
    public UpdateDirectorCommandValidator()
    {
      RuleFor(command => command.Model.Name).MinimumLength(4);
      RuleFor(command => command.Model.LastName).MinimumLength(4);
    } 
  }
}
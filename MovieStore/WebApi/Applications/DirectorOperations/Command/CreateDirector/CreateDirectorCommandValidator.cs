using FluentValidation;

namespace WebApi.Applications.DirectorOperations.Commands.CreateDirector
{
  public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
  {
    public CreateDirectorCommandValidator()
    {
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
    } 
  }
}
using FluentValidation;

namespace WebApi.Applications.ActorOperations.Commands.UpdateActor
{
  public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
  {
    public UpdateActorCommandValidator()
    {
      RuleFor(command => command.Model.Name).MinimumLength(4);
      RuleFor(command => command.Model.LastName).MinimumLength(4);
    } 
  }
}
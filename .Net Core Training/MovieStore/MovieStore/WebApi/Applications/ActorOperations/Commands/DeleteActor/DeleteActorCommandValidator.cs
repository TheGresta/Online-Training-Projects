using FluentValidation;
using WebApi.Applications.ActorOperations.Commands.DeleteActor;

namespace WebApi.Applications.ActorOperations.Commands.DeleteActor
{
  public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
  {
    public DeleteActorCommandValidator()
    {
      RuleFor(command => command.ActorId).GreaterThan(0);
    } 
  }
}
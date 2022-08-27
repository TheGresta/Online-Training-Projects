using FluentValidation;

namespace WebApi.Applications.SingerOperations.Commands.DeleteSinger
{
  public class DeleteSingerCommandValidator : AbstractValidator<DeleteSingerCommand>
  {
    public DeleteSingerCommandValidator()
    {
      RuleFor(command => command.SingerId).GreaterThan(0);
    } 
  }
}
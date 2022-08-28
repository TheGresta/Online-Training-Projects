using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.DeleteOrder
{
  public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
  {
    public DeleteOrderCommandValidator()
    {
      RuleFor(command => command.OrderId).GreaterThan(0);
    }
  }
}
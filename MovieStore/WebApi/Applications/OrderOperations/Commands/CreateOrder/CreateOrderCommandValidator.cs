using System;
using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.CreateOrder
{
  public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
  {
    public CreateOrderCommandValidator()
    {
      RuleFor(command => command.Model.BuyerId).GreaterThan(0);
      RuleFor(command => command.Model.MovieId).GreaterThan(0);
    }
  }
}

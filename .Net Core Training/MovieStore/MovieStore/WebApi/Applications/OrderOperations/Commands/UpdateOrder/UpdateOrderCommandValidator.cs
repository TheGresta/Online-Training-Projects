using System;
using FluentValidation;

namespace WebApi.Applications.OrderOperations.Commands.UpdateOrder
{
  public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
  {
    public UpdateOrderCommandValidator()
    {
      RuleFor(command => command.Model.MovieId).GreaterThan(0);
      RuleFor(command => command.Model.BuyerId).GreaterThan(0);
    }
  }
}
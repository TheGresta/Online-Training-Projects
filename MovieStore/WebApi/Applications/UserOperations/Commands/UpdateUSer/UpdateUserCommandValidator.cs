using System;
using FluentValidation;

namespace WebApi.Applications.UserOperations.Commands.UpdateUser
{
  public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
  {
    public UpdateUserCommandValidator()
    {
      RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
      RuleFor(command => command.Model.LastName).MinimumLength(4).When(x => x.Model.LastName.Trim() != string.Empty);
      RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(15);
      RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(5);
      RuleFor(command => command.Model.FavoriteGenreIDList).NotEmpty();
    } 
  }
}
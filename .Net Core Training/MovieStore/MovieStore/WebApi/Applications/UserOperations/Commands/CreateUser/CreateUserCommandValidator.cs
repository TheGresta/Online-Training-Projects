using FluentValidation;

namespace WebApi.Applications.UserOperations.Commands.CreateUser
{
  public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
  {
    public CreateUserCommandValidator()
    {
      RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(3);
      RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(15);
      RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(5);
      RuleFor(command => command.Model.FavoriteGenres).NotEmpty();
    } 
  }
}
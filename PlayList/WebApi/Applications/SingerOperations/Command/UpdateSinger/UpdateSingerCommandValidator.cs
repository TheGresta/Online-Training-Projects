using System;
using FluentValidation;

namespace WebApi.Applications.SingerOperations.Commands.UpdateSinger
{
  public class UpdateSingerCommandValidator : AbstractValidator<UpdateSingerCommand>
  {
    public UpdateSingerCommandValidator()
    {
      RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
      RuleFor(command => command.Model.LastName).MinimumLength(4).When(x => x.Model.LastName.Trim() != string.Empty);
      RuleFor(command => command.Model.BirthDate.Date).
      NotEmpty().LessThan(DateTime.Now.Date);
    } 
  }
}
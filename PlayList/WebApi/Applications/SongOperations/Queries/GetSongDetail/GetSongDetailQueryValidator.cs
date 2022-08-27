using FluentValidation;

namespace WebApi.Applications.SongOperations.Queries.GetSongDetail
{
  public class GetSongDetailQueryValidator : AbstractValidator<GetSongDetailQuery>
  {
    public GetSongDetailQueryValidator()
    {
      RuleFor(command => command.SongId).GreaterThan(0);
    }
  }
}
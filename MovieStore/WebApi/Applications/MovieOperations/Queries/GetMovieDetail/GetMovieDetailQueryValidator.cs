using FluentValidation;

namespace WebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
  public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
  {
    public GetMovieDetailQueryValidator()
    {
      RuleFor(command => command.MovieId).GreaterThan(0);
    }
  }
}
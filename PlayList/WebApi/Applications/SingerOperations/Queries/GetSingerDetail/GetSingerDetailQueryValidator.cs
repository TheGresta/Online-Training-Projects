using FluentValidation;

namespace WebApi.Applications.SingerOperations.Queries.GetSingerDetail
{
  public class GetSingerDetailQueryValidator : AbstractValidator<GetSingerDetailQuery>
  {
    public GetSingerDetailQueryValidator()
    {
      RuleFor(query => query.SingerId).GreaterThan(0);
    } 
  }
}
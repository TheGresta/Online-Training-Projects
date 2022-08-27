using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.ActorOperations.Command.CreateActor
{
  public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateActorCommandValidatorTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
      _mapper = testFixture.Mapper;
    }
    [Theory]
    [InlineData("", "ABCD")]
    [InlineData("ABCD", "")]
    [InlineData("A", "A")]
    [InlineData("ABCD", "A")]
    [InlineData("A", "ABCD")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string lastname)
    {
      CreateActorCommand command = new CreateActorCommand(_context);
      command.Model = new CreateActorModel()
      {
        Name = name,
        LastName = lastname
      };
      
      CreateActorCommandValidator validator = new CreateActorCommandValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
  }
}
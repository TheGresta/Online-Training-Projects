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
  public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateActorCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
      _mapper = testFixture.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      var actor =  new Actor(){Name = "Test_Robert", LastName = "Test_DeNiro"};
      _context.Actors.Add(actor);
      _context.SaveChanges();

      CreateActorCommand command = new CreateActorCommand(_context);
      command.Model = new CreateActorModel(){Name = actor.Name, LastName = actor.LastName};

      FluentActions
        .Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>()
        .And.Message.Should().Be("Actor Already Exist.");
    }
  }
}
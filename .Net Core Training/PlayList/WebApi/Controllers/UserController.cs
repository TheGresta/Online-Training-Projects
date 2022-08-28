using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Applications.UserOperations.Commands.CreateToken;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Applications.UserOperations.Commands.RefreshToken;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using static WebApi.Applications.UserOperations.Commands.CreateToken.CreateTokenCommand;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("[controller]s")]
  public class UserController : ControllerBase
  {
    private readonly IPlayListDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;
    public UserController(IPlayListDbContext context, IMapper mapper, IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserModel newUser)
    {
      CreateUserCommand command = new CreateUserCommand(_context, _mapper);
      command.Model = newUser;
      command.Handle();
      return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
    {
      CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);      
      command.Model = login;
      var token = command.Handle();
      return token;      
    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
      RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);      
      command.RefreshToken = token;
      var resultToken = command.Handle();
      return resultToken;      
    }
  }
}
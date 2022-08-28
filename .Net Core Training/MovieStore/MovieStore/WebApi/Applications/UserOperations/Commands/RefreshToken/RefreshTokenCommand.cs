using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Webapi.TokenOperations;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Applications.UserOperations.Commands.RefreshToken
{
  public class RefreshTokenCommand
  {
    public string RefreshToken { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IConfiguration _configuration;
    public RefreshTokenCommand(IMovieStoreDbContext context,  IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }
    public Token Handle()
    {
      var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
      if(user is not null)
      {
        TokenHandler handler = new TokenHandler(_configuration);
        Token token = handler.CreateAccessToken(user);

        user.RefreshToken = token.Refreshtoken;
        user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
        _context.SaveChanges();
        return token;
      }
      else
        throw new InvalidOperationException("Refresh Token is Invalid!");
    }
  }  
}
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace MiddlewarePractices.Middlewares
{
  public class HelloMiddleware
  {
    private readonly RequestDelegate _next;
    public HelloMiddleware(RequestDelegate next)
    {
      _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
      Console.WriteLine("Hello World");
      await _next.Invoke(context);
      Console.WriteLine("Bye World");
    }
  }
  static public class HelloMiddlewareExtension
  {
    static public IApplicationBuilder UseHello(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<HelloMiddleware>();
    }
  }
}
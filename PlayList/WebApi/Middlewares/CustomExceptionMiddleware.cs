using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using System.Net;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
  public class CustomExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILoggerService _loggerService;
    public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
    {
      _next = next;
      _loggerService = loggerService;
    }

    public async Task Invoke(HttpContext context)
    {
      var watch = Stopwatch.StartNew();

      try
      {        
        string message = "[Request] Http " + context.Request.Method + " - " + context.Request.Path;
        _loggerService.Write(message);

        await _next(context);
        watch.Stop();

        message = "[Response] Http " + context.Request.Method + " - " + context.Request.Path + " - Responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
        _loggerService.Write(message);
      }
      catch(Exception ex)
      {
        watch.Stop();
        await HandleExceptiona(context, ex, watch);
      }
      
    }

    private Task HandleExceptiona(HttpContext context, Exception ex, Stopwatch watch)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      string message = "[Error]    HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message : " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
      _loggerService.Write(message);

      var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);
      
      return context.Response.WriteAsync(result);
    }
  }

  public static class CustomExceptionMiddlewareExtension
  {
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
  }
}
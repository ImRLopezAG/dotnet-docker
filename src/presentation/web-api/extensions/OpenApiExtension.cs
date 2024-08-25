using System.Net;
using Microsoft.OpenApi.Models;

namespace web_api;

public static class OpenApiExtension
{
  public static OpenApiResponses Add(this OpenApiResponses operation, HttpStatusCode statusCode, Func<OpenApiResponseBuilder, OpenApiResponseBuilder> func)
  {
    var builder = new OpenApiResponseBuilder();
    func(builder);
    var response = builder.Build();
    operation.Add(((int)statusCode).ToString(), response);
    return operation;
  }

  public static RouteHandlerBuilder WithResponses(this RouteHandlerBuilder builder, HttpStatusCode statusCode, Func<OpenApiResponseBuilder, OpenApiResponseBuilder> func)
  {
    var res = new OpenApiResponseBuilder();
    func(res);
    var response = res.Build();
    builder.WithOpenApi(opt =>
    {
      opt.Responses.Add(((int)statusCode).ToString(), response);
      return opt;
    });
    return builder;
  }
}

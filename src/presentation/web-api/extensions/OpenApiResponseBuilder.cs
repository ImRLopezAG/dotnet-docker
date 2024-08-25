using Microsoft.OpenApi.Models;

namespace web_api;

public class OpenApiResponseBuilder
{
  private readonly OpenApiResponse _response;
  public OpenApiResponseBuilder()
  {
    _response = new OpenApiResponse();
  }

  public OpenApiResponseBuilder AddDescription(string description)
  {
    _response.Description = description;
    return this;
  }

  public OpenApiResponseBuilder AddHeaders(IDictionary<string, OpenApiHeader> headers)
  {
    _response.Headers = headers;
    return this;
  }

  public OpenApiResponseBuilder AddContent(Func<IDictionary<string, OpenApiMediaType>, IDictionary<string, OpenApiMediaType>> func)
  {
    var content = new Dictionary<string, OpenApiMediaType>();
    func(content);
    _response.Content = content;
    return this;
  }

  public OpenApiResponseBuilder AddLink(IDictionary<string, OpenApiLink> link)
  {
    _response.Links = link;
    return this;
  }

  public OpenApiResponse Build()
  {
    return _response;
  }
}

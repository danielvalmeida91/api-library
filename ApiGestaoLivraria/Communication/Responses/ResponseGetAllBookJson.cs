using System;

namespace ApiGestaoLivraria.Communication.Responses;

public class ResponseGetAllBookJson
{
  public string Title { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public string Genre { get; set; } = string.Empty;
  public int Stock { get; set; }
}

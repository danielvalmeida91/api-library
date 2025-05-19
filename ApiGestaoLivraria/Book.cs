using System;
using ApiGestaoLivraria.Enums;

namespace ApiGestaoLivraria;

public class Book
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public Genre Genre { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }

  public string GenreString => Genre.ToString();

}

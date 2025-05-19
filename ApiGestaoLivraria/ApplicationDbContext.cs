using System;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoLivraria;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  { }

  public DbSet<Book> Books { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Book>(
      entity =>
      {
        entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
      }
    );
  }
}

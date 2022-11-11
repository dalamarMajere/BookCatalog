using BookCatalogWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookCatalogWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
}

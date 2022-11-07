using BookCatalogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogWeb.Data;

public class ApplicationDbContext : DbContext
{
    private List<string> _categories = new() {"Fantasy", "Professional", "C#", "Unity", "Finance"};

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public List<string> Categories { get => _categories; set => _categories = value; }
}

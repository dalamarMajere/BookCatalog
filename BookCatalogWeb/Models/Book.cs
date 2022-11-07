using System.ComponentModel.DataAnnotations;

namespace BookCatalogWeb.Models;

public record Book
{
    [Key]
    public int Id { get; init; }
    [Required(ErrorMessage = "Please provide a name for this book!")]
    public string Name { get; init; }
    public string Category { get; init; }
    public int DisplayOrder { get; init; }
    public DateTime CreatedDateTime { get; init; } = DateTime.Now;
}

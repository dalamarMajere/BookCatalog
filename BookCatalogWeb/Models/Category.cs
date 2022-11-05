using System.ComponentModel.DataAnnotations;

namespace BookCatalogWeb.Models;

public record Category
{
    [Key]
    public int Id { get; init; } 
    [Required]
    public string Name { get; init; }
    public int DisplayOrder { get; init; }
    public DateTime CreatedDateTime { get; init; } = DateTime.Now;
}

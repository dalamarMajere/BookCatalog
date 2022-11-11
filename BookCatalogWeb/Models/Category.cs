using System.ComponentModel.DataAnnotations;

namespace BookCatalogWeb.Models;

public record Category
{
	[Key]
	public int Id { get; init; }
	[Required] 
	public string Name { get; init; }
	public string Description { get; init; }

	public bool IsSelected { get; init; }
}



namespace BookCatalogWeb.Models;

public class BookWithCategories
{
    public Book Book { get; set; }
    public IEnumerable<string> Categories { get; set; }
}

namespace BookCatalogWeb.Models
{
    public record BookWithCategories
    {
        public BookWithCategories()
        {
            Categories = new List<string>();
            Book book = new Book();
        }

        public Book Book { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}

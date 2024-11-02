namespace BookStoreCRUD.Web.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string Genre { get; set; }
        public int StockQuantity { get; set; }
    }
}

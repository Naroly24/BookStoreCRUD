using System.ComponentModel.DataAnnotations;

namespace BookStoreCRUD.Domain.Models 
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        [Range(1, 1000, ErrorMessage = "Precio debe estar entre 1 y 1000")]
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string Genre { get; set; }
        [Range(1, 100, ErrorMessage = "Cantidad debe estar entre 1 y 100")]
        public int StockQuantity { get; set; }
    }
}

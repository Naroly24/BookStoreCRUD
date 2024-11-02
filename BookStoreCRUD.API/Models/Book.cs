using System.ComponentModel.DataAnnotations;

namespace BookStoreCRUD.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo.")]
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string Genre { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock debe ser un número positivo.")]
        public int StockQuantity { get; set; }
    }
}

namespace BookStoreCRUD.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; } 
        public int QuantityInStock { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}

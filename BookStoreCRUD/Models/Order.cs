namespace BookStoreCRUD.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; } 
        public required string OrderStatus { get; set; }

        
        public ICollection<OrderItem>? OrderItems { get; set; }
    }

}

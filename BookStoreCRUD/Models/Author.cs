namespace BookStoreCRUD.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Nationality { get; set; }
    }

}

﻿namespace BookStoreCRUD.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }

}
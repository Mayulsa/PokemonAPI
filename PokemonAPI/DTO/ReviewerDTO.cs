﻿using PokemonAPI.Models;

namespace PokemonAPI.DTO
{
    public class ReviewerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

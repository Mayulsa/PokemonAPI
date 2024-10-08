﻿using System.Diagnostics.Metrics;

namespace PokemonAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        //public ICollection<Pokemon> Pokemons { get; set; }
    }
}

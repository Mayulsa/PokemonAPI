﻿using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        public ICollection<Owner> GetOwnersOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p=>p.Pokemon.Id == pokeId).Select(o =>o.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(o=>o.Owner.Id == ownerId).Select(p=>p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o=> o.Id == ownerId);
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        

        public ReviewRepository(DataContext context)
        {
            _context = context;
            
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(p => p.Pokemon.Id == pokeId).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }
    }
}

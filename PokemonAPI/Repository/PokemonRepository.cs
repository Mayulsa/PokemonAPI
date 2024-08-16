using PokemonAPI.Data;

namespace PokemonAPI.Repository
{
    public class PokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
    }
}

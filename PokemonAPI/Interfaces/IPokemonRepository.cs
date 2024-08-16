using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}

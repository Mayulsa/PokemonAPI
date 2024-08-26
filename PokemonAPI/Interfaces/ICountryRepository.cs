using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountry();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountryId(int id);
        bool CountryExists(int id);
    }
}

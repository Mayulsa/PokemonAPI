using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountryId(int countryId);
        bool CountryExists(int id);
    }
}

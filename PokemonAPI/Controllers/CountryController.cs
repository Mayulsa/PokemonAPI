using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.DTO;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Repository;
using System.Diagnostics.Metrics;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)//Esto es un constructor
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDTO>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();
            var country = _mapper.Map<CountryDTO>(_countryRepository.GetCountry(countryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDTO>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);

        }

        //[HttpGet("{countryId}/owners")]
        //[ProducesResponseType(200, Type = typeof(Owner))]
        //[ProducesResponseType(400)]
        //public IActionResult GetOwnerByCountryId(int countryId)
        //{
        //    if (!_countryRepository.CountryExists(countryId))
        //        return NotFound();
        //    var owner = _mapper.Map<List<OwnerDTO>>(_countryRepository.GetOwnersByCountryId(countryId));
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    return Ok(owner);
        //}

    }
}

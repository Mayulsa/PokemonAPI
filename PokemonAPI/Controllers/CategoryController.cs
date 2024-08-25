using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Data;
using PokemonAPI.DTO;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Repository;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);

        }


    }
}

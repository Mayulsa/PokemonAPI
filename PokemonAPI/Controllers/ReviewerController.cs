using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.DTO;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Repository;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController :Controller
    {
        private readonly IReviewerRespository _reviewerRespository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRespository reviewerRespository, IMapper mapper)
        {
            _reviewerRespository = reviewerRespository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewer = _mapper.Map<List<ReviewerDTO>>(_reviewerRespository.GetReviewers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);

        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviewerRespository.ReviewerExists(reviewerId))
                return NotFound();
            var reviewer = _mapper.Map<ReviewerDTO>(_reviewerRespository.GetReviewer(reviewerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer( int reviewerId)
        {
            if (!_reviewerRespository.ReviewerExists(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewerDTO>>(_reviewerRespository.GetReviewByReviewer(reviewerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }

        //para cuando los demas campos en el estadui quisquella tenemos que ser basicos  
    }
}

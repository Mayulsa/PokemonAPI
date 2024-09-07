using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface IReviewerRespository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}

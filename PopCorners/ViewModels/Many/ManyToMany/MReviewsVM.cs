using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MReviewsVM : BaseManyViewModel<ReviewService, ReviewDTO, Review>
    {
        public MReviewsVM() : base("Reviews")
        {

        }
    }
}

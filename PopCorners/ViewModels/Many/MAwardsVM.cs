using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MAwardsVM : BaseManyViewModel<AwardService, AwardDTO, Award>
    {
        public MAwardsVM() : base("Awards")
        {

        }
    }
}

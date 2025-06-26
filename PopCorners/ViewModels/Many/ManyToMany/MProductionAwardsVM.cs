using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MProductionAwardsVM : BaseManyViewModel<ProductionAwardService, ProductionAwardDTO, ProductionAward>
    {
        public MProductionAwardsVM() : base("Production Awards")
        {

        }
    }
}

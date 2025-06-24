using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MProductionCastsVM : BaseManyViewModel<ProductionCastService, ProductionCastDTO, ProductionCast>
    {
        public MProductionCastsVM() : base("Production casts")
        {

        }

        protected override void ClearFilters()
        {
            throw new NotImplementedException();
        }
    }
}

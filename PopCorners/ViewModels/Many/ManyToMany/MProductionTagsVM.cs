using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MProductionTagsVM : BaseManyViewModel<ProductionTagService, ProductionTagDTO, ProductionTag>
    {
        public MProductionTagsVM() : base("Production tags")
        {

        }
    }
}

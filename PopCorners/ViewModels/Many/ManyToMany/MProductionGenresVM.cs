using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MProductionGenresVM : BaseManyViewModel<ProductionGenreService, ProductionGenreDTO, ProductionGenre>
    {
        public MProductionGenresVM() : base("Production genres")
        {

        }
    }
}

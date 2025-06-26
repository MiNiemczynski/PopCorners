using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MGenresVM : BaseManyViewModel<GenreService, GenreDTO, Genre>
    {
        public MGenresVM() : base("Genres")
        {

        }
    }
}

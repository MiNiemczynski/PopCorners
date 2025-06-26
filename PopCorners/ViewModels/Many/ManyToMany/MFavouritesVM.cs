using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many.ManyToMany
{
    public class MFavouritesVM : BaseManyViewModel<FavouriteService, FavouriteDTO, Favourite>
    {
        public MFavouritesVM() : base("Favourites")
        {

        }
    }
}

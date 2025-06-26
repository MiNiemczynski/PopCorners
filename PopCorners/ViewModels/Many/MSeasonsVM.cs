using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MSeasonsVM : BaseManyViewModel<SeasonService, SeasonDTO, Season>
    {

        public bool NoEpisodes
        {
            get => Service.NoEpisodes;
            set
            {
                if (value != Service.NoEpisodes)
                {
                    Service.NoEpisodes = value;
                    OnPropertyChanged(() => NoEpisodes);
                }
            }
        }
        public MSeasonsVM() : base("Seasons")
        {

        }

        protected override void ClearFilters()
        {
            NoEpisodes = true;
            SetDefaultSearchOption();
            Refresh();
        }
    }
}

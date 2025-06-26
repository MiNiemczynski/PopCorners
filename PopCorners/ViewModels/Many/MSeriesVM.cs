using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;

namespace PopCorners.ViewModels.Many
{
    public class MSeriesVM : BaseManyViewModel<SeriesService, SeriesDTO, Series>
    {
        public bool HasDescription
        {
            get => Service.HasDescription;
            set
            {
                if (value != Service.HasDescription)
                {
                    Service.HasDescription = value;
                    OnPropertyChanged(() => HasDescription);
                }
            }
        }
        public bool NoSeasons
        {
            get => Service.NoSeasons;
            set
            {
                if (value != Service.NoSeasons)
                {
                    Service.NoSeasons = value;
                    OnPropertyChanged(() => NoSeasons);
                }
            }
        } 
        public MSeriesVM() : base("All Series")
        {

        }

        protected override void ClearFilters()
        {
            HasDescription = false;
            NoSeasons = true;
            SetDefaultSearchOption();
            Refresh();
        }
    }
}

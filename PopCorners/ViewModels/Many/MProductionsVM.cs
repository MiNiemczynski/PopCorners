using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
namespace PopCorners.ViewModels.Many
{
    public class MProductionsVM : BaseManyViewModel<ProductionService, ProductionDTO, Production>
    {
        public List<SerialMovieComboBoxDTO> SerialMovieOptions { get; set; }

        public MProductionsVM() : base("Productions")
        {
            SerialMovieOptions = new()
            {
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.All,
                    OptionName = "All"
                },
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.Movie,
                    OptionName = "Movies"
                },
                new SerialMovieComboBoxDTO()
                {
                    SelectedOption = SerialMovieEnum.Series,
                    OptionName = "Series"
                }
            };
        }

        public bool HasPlatform
        {
            get => Service.HasPlatform;
            set
            {
                if (value != Service.HasPlatform)
                {
                    Service.HasPlatform = value;
                    OnPropertyChanged(() => HasPlatform);
                }
            }
        }
        public SerialMovieEnum SerialMovie
        {
            get => Service.SerialMovieOption;
            set
            {
                if (value != Service.SerialMovieOption)
                {
                    Service.SerialMovieOption = value;
                    OnPropertyChanged(() => SerialMovie);
                }
            }
        }
    }
}

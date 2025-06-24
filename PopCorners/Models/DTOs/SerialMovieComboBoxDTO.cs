using PopCorners.Helpers;

namespace PopCorners.Models.DTOs
{
    public class SerialMovieComboBoxDTO
    {
        public SerialMovieEnum SelectedOption { get; set; }
        public string OptionName { get; set; } = default!;
    }
}

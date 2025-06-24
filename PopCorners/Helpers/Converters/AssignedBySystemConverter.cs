using System.Globalization;
using System.Windows.Data;

namespace PopCorners.Helpers.Converters
{
    public class AssignedBySystemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return "Assigned by system";
            if (double.TryParse(value.ToString(), out double number))
                if (number == 0)
                    return "Assigned by system";
            return value.ToString() ?? "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Globalization;
using System.Windows.Data;

namespace PopCorners.Helpers.Converters
{
    public class DateTimeInWordsDateConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value as DateTime?)?.ToString("D");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

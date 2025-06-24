using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PopCorners.Helpers.Converters
{
    public class DateOnlyToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateOnly dateOnly)
                return dateOnly.ToDateTime(TimeOnly.MinValue);
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
                return DateOnly.FromDateTime(dateTime);
            return DependencyProperty.UnsetValue;
        }
    }
}

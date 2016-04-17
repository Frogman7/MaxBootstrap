using System;
using System.Globalization;
using System.Windows.Data;
using Display = MaxBootstrap.Core.Enums.FeatureEnums.Display;

namespace MaxBootstrap.UI.Converters
{
    public class DisplayToIsExpandedBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var display = (Display)value;

            return display == Display.Expanded;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

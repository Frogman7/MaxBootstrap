using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using Display = MaxBootstrap.Core.Enums.FeatureEnums.Display;

namespace MaxBootstrap.UI.Converters
{
    public class DisplayToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var display = (Display)value;

            switch (display)
            {
                case Display.Collasped:
                case Display.Expanded:
                    return Visibility.Visible;
                case Display.Hidden:
                    return Visibility.Hidden;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

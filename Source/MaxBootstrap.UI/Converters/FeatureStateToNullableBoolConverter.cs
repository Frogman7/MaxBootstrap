using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.UI.Converters
{
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Data;

    using Core.Enums;

    public class FeatureStateToNullableBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var featureState = (FeatureSelectedState.SelectedState)value;

            switch (featureState)
            {
                case FeatureSelectedState.SelectedState.Selected:
                    {
                        return true;
                    }

                case FeatureSelectedState.SelectedState.Partial:
                    {
                        return null;
                    }

                case FeatureSelectedState.SelectedState.Unselected:
                    {
                        return false;
                    }

                default:
                    {
                        throw new InvalidEnumArgumentException();
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullabeBool = (bool?)value;

            if (nullabeBool.HasValue)
            {
                if (nullabeBool.Value)
                {
                    return FeatureSelectedState.SelectedState.Selected;
                }
                else
                {
                    return FeatureSelectedState.SelectedState.Unselected;
                }
            }
            else
            {
                return FeatureSelectedState.SelectedState.Partial;
            }
        }
    }
}

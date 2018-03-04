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
    using static MaxBootstrap.UI.Views.Features.FeatureViewmodel;

    public class FeatureStateToNullableBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var featureState = (SelectedState)value;

            switch (featureState)
            {
                case SelectedState.Selected:
                    {
                        return true;
                    }

                case SelectedState.Partial:
                    {
                        return null;
                    }

                case SelectedState.Unselected:
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
                    return SelectedState.Selected;
                }
                else
                {
                    return SelectedState.Unselected;
                }
            }
            else
            {
                return SelectedState.Partial;
            }
        }
    }
}

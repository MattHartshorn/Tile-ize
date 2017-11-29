using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace ProjectTile.UWP.Util
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ^ (parameter as string ?? string.Empty).Equals("Reverse") ?
                Visibility.Visible : Visibility.Collapsed;
        }
            

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Visibility)value == Visibility.Visible ^ (parameter as string ?? string.Empty).Equals("Reverse");
        }

    }
}

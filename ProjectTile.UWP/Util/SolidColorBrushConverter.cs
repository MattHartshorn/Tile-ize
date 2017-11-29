using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;

namespace ProjectTile.UWP.Util
{
    public class SolidColorBrushConverter : IValueConverter
    {
        public static SolidColorBrush Convert(string colorHex)
        {
            colorHex = colorHex.Replace("#", string.Empty);

            var i = -2;

            var a = (byte)0xFF;
            if (colorHex.Length > 6)
                a = (byte)(System.Convert.ToUInt32(colorHex.Substring((i += 2), 2), 16));

            var r = (byte)(System.Convert.ToUInt32(colorHex.Substring((i += 2), 2), 16));
            var g = (byte)(System.Convert.ToUInt32(colorHex.Substring((i += 2), 2), 16));
            var b = (byte)(System.Convert.ToUInt32(colorHex.Substring((i += 2), 2), 16));

            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        public SolidColorBrushConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string colorHex = value as string;
            if (!String.IsNullOrEmpty(colorHex))
                return Convert(colorHex);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = value as SolidColorBrush;
            if (brush != null)
            {
                return String.Format("#{0}{1}{2}{3}",
                    brush.Color.A,
                    brush.Color.R,
                    brush.Color.G,
                    brush.Color.B
                );
            }

            return value.ToString();
        }
    }
}

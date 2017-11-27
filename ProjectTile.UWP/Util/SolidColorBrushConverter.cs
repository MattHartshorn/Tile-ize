using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ProjectTile.UWP.Util
{
    public static class SolidColorBrushConverter
    {
        public static SolidColorBrush Convert(string colorHex)
        {
            colorHex = colorHex.Replace("#", string.Empty);

            var a = (byte)(System.Convert.ToUInt32(colorHex.Substring(0, 2), 16));
            var r = (byte)(System.Convert.ToUInt32(colorHex.Substring(2, 2), 16));
            var g = (byte)(System.Convert.ToUInt32(colorHex.Substring(4, 2), 16));
            var b = (byte)(System.Convert.ToUInt32(colorHex.Substring(6, 2), 16));

            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }
    }
}

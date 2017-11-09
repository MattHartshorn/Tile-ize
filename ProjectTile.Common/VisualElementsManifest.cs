using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTile.Common
{


    public class VisualElementsManifest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool TextThemeLight { get; set; }
        
        public int ColorInt32 { get; set; }
        
        public string IconURI { get; set; }

        public string SmallIconURI { get; set; }

        public string GetColorHex()
        {
            return String.Format("{0:X}", this.ColorInt32);
        }

    }
}

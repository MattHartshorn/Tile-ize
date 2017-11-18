using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Controls;

namespace ProjectTile.UWP.ViewModels
{
    class NavigationMenuItemViewModel : ViewModelBase
    {
        private string _label;
        private string _iconGlyph;
        private object _tag;


        public NavigationMenuItemViewModel()
        {

        }

        public NavigationMenuItemViewModel(string label, string iconGlyph)
            : this(label, iconGlyph, null)
        {
        }

        public NavigationMenuItemViewModel(string label, string iconGlyph, object tag)
        {
            this._label = label;
            this._iconGlyph = iconGlyph;
            this._tag = tag;
        }


        public string Label
        {
            get { return this._label; }
            set
            {
                this._label = value;
                RaisePropertyChanged(nameof(Label));
            }
        }

        public string IconGlyph
        {
            get { return this._iconGlyph; }
            set
            {
                this._iconGlyph = value;
                RaisePropertyChanged(nameof(IconGlyph));
            }
        }

        public object Tag
        {
            get { return this._tag; }
            set
            {
                this._tag = value;
                RaisePropertyChanged(nameof(Tag));
            }
        }
    }
}

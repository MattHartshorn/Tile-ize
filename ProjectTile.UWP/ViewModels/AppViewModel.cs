using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ProjectTile.UWP.ViewModels
{
    class AppViewModel : ViewModelBase
    {
        private string _displayName;
        private string _backgroundColor;
        private string _iconSource;

        public AppViewModel(int appID)
        {
            this.AppID = AppID;
        }

        public int AppID
        {
            get;
        }

        public string DisplayName
        {
            get { return this._displayName; }
            set
            {
                this._displayName = value;
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string BackgroundColor
        {
            get { return this._backgroundColor; }
            set
            {
                this._backgroundColor = value;
                RaisePropertyChanged(nameof(BackgroundColor));
            }
        }

        public string IconSource
        {
            get { return this._iconSource; }
            set
            {
                this._iconSource = value;
                RaisePropertyChanged(nameof(IconSource));
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ProjectTile.UWP.ViewModels
{
    class ThemeIconAppViewModel : ViewModelBase
    {
        private string _appColor;

        public string AppColor
        {
            get { return this._appColor; }
            set
            {
                this._appColor = value;
                RaisePropertyChanged(nameof(AppColor));
            }
        }
    }
}

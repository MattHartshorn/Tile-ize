using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ProjectTile.UWP.ViewModels
{
    class StylesPageViewModel : ViewModelBase
    {
        private string _selectedColor;
        private string _largeIconSource;
        private string _mediumIconSource;
        private string _smallIconSource;
        private string _displayName;
        private string _tileFontColor;
        private bool _isLargeTileTextVisible;
        private bool _isLargeIconResetEnabled;
        private bool _isMediumIconResetEnabled;
        private bool _isSmallIconResetEnabled;
        private string _appName;
        private string _toggleDetailsText;
        private bool _isAppDetailsVisible;
        private string _shortcutPath;
        private string _executablePath;
        private ObservableCollection<string> _recentColors;
        private ObservableCollection<string> _windowsColors;
        private string _selectedRecentColor;
        private string _selectedWindowsColor;
        private bool _isFontLight;
        private bool _isFontDark;


        public StylesPageViewModel()
        {
            this.ResetIconCommand = new RelayCommand<string>(OnResetIconCommandAction);
            this.ToggleDetailsCommand = new RelayCommand(OnToggleDetailsCommandAction);
            this.CustomColorCommand = new RelayCommand(OnCustomColorCommandAction);

            this.ToggleDetailsText = "Show Details";
            this.IsAppDetailsVisible = false;

            InitializeWindowsColors();
            InitData();
        }


        public string SelectedColor
        {
            get { return this._selectedColor; }
            set
            {
                this._selectedColor = value;
                RaisePropertyChanged(nameof(SelectedColor));
            }
        }

        public string LargeIconSource
        {
            get { return this._largeIconSource; }
            set
            {
                this._largeIconSource = value;
                RaisePropertyChanged(nameof(LargeIconSource));
            }
        }

        public string MediumIconSource
        {
            get { return this._mediumIconSource; }
            set
            {
                this._mediumIconSource = value;
                RaisePropertyChanged(nameof(MediumIconSource));
            }
        }

        public string SmallIconSource
        {
            get { return this._smallIconSource; }
            set
            {
                this._smallIconSource = value;
                RaisePropertyChanged(nameof(SmallIconSource));
            }
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

        public string TileFontColor
        {
            get { return this._tileFontColor; }
            set
            {
                this._tileFontColor = value;
                RaisePropertyChanged(nameof(TileFontColor));
            }
        }

        public bool IsLargeTileTextVisible
        {
            get { return this._isLargeTileTextVisible; }
            set
            {
                this._isLargeTileTextVisible = value;
                RaisePropertyChanged(nameof(IsLargeTileTextVisible));
            }
        }

        public bool IsLargeIconResetEnabled
        {
            get { return this._isLargeIconResetEnabled; }
            set
            {
                this._isLargeIconResetEnabled = value;
                RaisePropertyChanged(nameof(IsLargeIconResetEnabled));
            }
        }

        public bool IsMediumIconResetEnabled
        {
            get { return this._isMediumIconResetEnabled; }
            set
            {
                this._isMediumIconResetEnabled = value;
                RaisePropertyChanged(nameof(IsMediumIconResetEnabled));
            }
        }

        public bool IsSmallIconResetEnabled
        {
            get { return this._isSmallIconResetEnabled; }
            set
            {
                this._isSmallIconResetEnabled = value;
                RaisePropertyChanged(nameof(IsSmallIconResetEnabled));
            }
        }

        public string AppName
        {
            get { return this._appName; }
            set
            {
                this._appName = value;
                RaisePropertyChanged(nameof(AppName));
            }
        }

        public string ToggleDetailsText
        {
            get { return this._toggleDetailsText; }
            set
            {
                this._toggleDetailsText = value;
                RaisePropertyChanged(nameof(ToggleDetailsText));
            }
        }

        public bool IsAppDetailsVisible
        {
            get { return this._isAppDetailsVisible; }
            set
            {
                this._isAppDetailsVisible = value;
                RaisePropertyChanged(nameof(IsAppDetailsVisible));
            }
        }

        public string ShortcutPath
        {
            get { return this._shortcutPath; }
            set
            {
                this._shortcutPath = value;
                RaisePropertyChanged(nameof(ShortcutPath));
            }
        }

        public string ExecutablePath
        {
            get { return this._executablePath; }
            set
            {
                this._executablePath = value;
                RaisePropertyChanged(nameof(ExecutablePath));
            }
        }

        public ObservableCollection<string> RecentColors
        {
            get { return this._recentColors; }
            set
            {
                this._recentColors = value;
                RaisePropertyChanged(nameof(RecentColors));
            }
        }

        public ObservableCollection<string> WindowsColors
        {
            get { return this._windowsColors; }
            set
            {
                this._windowsColors = value;
                RaisePropertyChanged(nameof(WindowsColors));
            }
        }

        public string SelectedRecentColor
        {
            get { return this._selectedRecentColor; }
            set
            {
                this._selectedRecentColor = value;
                RaisePropertyChanged(nameof(SelectedRecentColor));

                if (value != null)
                    this.SelectedColor = value;
                else
                    this.SelectedWindowsColor = null;
            }
        }

        public string SelectedWindowsColor
        {
            get { return this._selectedWindowsColor; }
            set
            {
                this._selectedWindowsColor = value;
                RaisePropertyChanged(nameof(SelectedWindowsColor));

                if (value != null)
                    this.SelectedColor = value;
                else
                    this.SelectedRecentColor = null;
            }
        }

        public bool IsFontLight
        {
            get { return this._isFontLight; }
            set
            {
                this._isFontLight = value;
                RaisePropertyChanged(nameof(IsFontLight));

                if (value) this.TileFontColor = "#FFFFFF";
            }
        }

        public bool IsFontDark
        {
            get { return this._isFontDark; }
            set
            {
                this._isFontDark = value;
                RaisePropertyChanged(nameof(IsFontDark));

                if (value) this.TileFontColor = "#000000";
            }
        }

        public RelayCommand<string> ResetIconCommand
        {
            get;
        }

        public RelayCommand ToggleDetailsCommand
        {
            get;
        }

        public RelayCommand CustomColorCommand
        {
            get;
        }


        private void InitializeWindowsColors()
        {
            this.WindowsColors = new ObservableCollection<string>
            {
                "#FFB900",
                "#FF8C00",
                "#F7630C",
                "#CA5010",
                "#DA3B01",
                "#EF6950",
                "#D13438",
                "#FF4343",
                "#E74856",
                "#E81123",
                "#EA005E",
                "#C30052",
                "#E3008C",
                "#BF0077",
                "#C239B3",
                "#9A0089",
                "#0078D7",
                "#0063B1",
                "#8E8CD8",
                "#6B69D6",
                "#8764B8",
                "#744DA9",
                "#B146C2",
                "#881798",
                "#0099BC",
                "#2D7D9A",
                "#00B7C3",
                "#038387",
                "#00B294",
                "#018574",
                "#00CC6A",
                "#10893E",
                "#7A7574",
                "#5D5A58",
                "#68768A",
                "#515C6B",
                "#567C73",
                "#486860",
                "#498205",
                "#107C10",
                "#767676",
                "#4C4A48",
                "#69797E",
                "#4A5459",
                "#647C64",
                "#525E54",
                "#847545",
                "#7E735F"
            };
        }

        private void InitData()
        {
            this.AppName = "Demo App";
            this.DisplayName = "Demo App";
            this.SelectedColor = "#1867E6";
            this.RecentColors = new ObservableCollection<string>()
            {
                "#1867E6",
                "#E05B8E",
                "#326336",
                "#8C7FEF"
            };
            this.SelectedRecentColor = this.RecentColors[0];
            this.IsFontDark = true;
            this.IsLargeTileTextVisible = true;
            this.LargeIconSource = "ms-appx:///Assets/Square150x150Logo.scale-100.png";
            this.MediumIconSource = "ms-appx:///Assets/Square150x150Logo.scale-100.png";
            this.SmallIconSource = "ms-appx:///Assets/Square44x44Logo.scale-100.png";
            this.ShortcutPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Demo App.lnk";
            this.ExecutablePath = @"C:\Program Files\Company\Demo\bin\DemoApp.exe";
        }

        private void OnResetIconCommandAction(string iconType)
        {

        }

        private void OnToggleDetailsCommandAction()
        {
            this.IsAppDetailsVisible = !this.IsAppDetailsVisible;
            this.ToggleDetailsText = (this.IsAppDetailsVisible) ? "Hide Details" : "Show Details";
        }
        
        private void OnCustomColorCommandAction()
        {

        }
    }
}

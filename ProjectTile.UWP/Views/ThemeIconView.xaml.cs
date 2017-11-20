using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProjectTile.UWP.Views
{
    public sealed partial class ThemeIconView : UserControl
    {
        public static readonly DependencyProperty ThemeBackgroundSourceProperty = DependencyProperty.Register(
            "ThemeBackgroundSource", 
            typeof(ImageSource), 
            typeof(ThemeIconView), 
            new PropertyMetadata(null));

        public ThemeIconView()
        {
            this.InitializeComponent();
        }

        public ImageSource ThemeBackgroundSource
        {
            get { return GetValue(ThemeBackgroundSourceProperty) as ImageSource; }
            set { SetValue(ThemeBackgroundSourceProperty, value); }
        }
    }
}

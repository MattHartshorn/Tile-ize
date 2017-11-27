using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProjectTile.UWP.Views
{
    public sealed partial class ThemeIconView : UserControl
    {
        public static readonly DependencyProperty ThemeBackgroundSourceProperty = DependencyProperty.Register(
            "ThemeBackgroundSource", 
            typeof(ImageSource), 
            typeof(ThemeIconView), 
            new PropertyMetadata(new Uri("ms-appx:///Assets/DefaultThemeBackground.png", UriKind.Absolute)));

        public static readonly DependencyProperty AppColorItemSourceProperty = DependencyProperty.Register(
            "AppColorItemSource",
            typeof(object),
            typeof(ThemeIconView),
            new PropertyMetadata(null));


        private readonly List<Rectangle> _appGridRectangles;

        public ThemeIconView()
        {
            this.InitializeComponent();
            this.DataContext = this;

            this._appGridRectangles = new List<Rectangle>();
            GetAppRectangles();
            SetAppGridColors();
        }


        public ImageSource ThemeBackgroundSource
        {
            get { return GetValue(ThemeBackgroundSourceProperty) as ImageSource; }
            set { SetValue(ThemeBackgroundSourceProperty, value); }
        }

        public object AppColorItemSource
        {
            get { return GetValue(AppColorItemSourceProperty); }
            set
            {
                SetValue(AppColorItemSourceProperty, value);
                SetAppGridColors();
            }
        }


        private void GetAppRectangles()
        {
            foreach (var child in this.AppGrid.Children)
            {
                if (child is Rectangle)
                    this._appGridRectangles.Add(child as Rectangle);
            }
        }

        private void SetAppGridColors()
        {
            var defaultBrush = Application.Current.Resources["SystemControlAccentAcrylicElementAccentMediumHighBrush"] as Brush;

            // Reset the app grid colors
            foreach (var rect in this._appGridRectangles)
                rect.Fill = defaultBrush;

            // Change all the colors
            int i = 0;
            this.AppListPanel.Items.Clear();
            if (this.AppColorItemSource is IEnumerable)
            {
                foreach (var appColor in (this.AppColorItemSource as IEnumerable))
                {
                    var brush = appColor as Brush;

                    if (brush == null)
                    {
                        if (appColor is Color)
                        {
                            brush = new SolidColorBrush((Color)appColor);
                        }
                        else if (appColor is string)
                        {
                            brush = Util.SolidColorBrushConverter.Convert(appColor as string);
                        }
                    }

                    if (brush != null)
                    {
                        if (i <= 8)
                        {
                            this.AppListPanel.Items.Add(brush);
                        }
                        if (i < this._appGridRectangles.Count)
                        {
                            this._appGridRectangles[i].Fill = brush;
                        }
                    }

                    i++;
                }
            }

            // Add missing apps from list
            for (var j = i; j < 8; j++)
                this.AppListPanel.Items.Add(defaultBrush);
        }
    }
}

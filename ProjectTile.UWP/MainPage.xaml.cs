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
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using ProjectTile.Common;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectTile.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnNavigationViewBtnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationView.IsPaneOpen = !this.NavigationView.IsPaneOpen;
        }

        //private async void OnRequestReceived(Windows.ApplicationModel.AppService.AppServiceConnection sender, Windows.ApplicationModel.AppService.AppServiceRequestReceivedEventArgs args)
        //{
        //    var deferral = args.GetDeferral();
        //    var status = args.Request.Message["status"];

        //    if (status != null && status.Equals(AppServiceStatus.Ready))
        //    {
        //        this.txtStatus.Text = "Ready";
        //    }
        //    await args.Request.SendResponseAsync(new ValueSet());
        //    deferral.Complete();
        //}
    }
}
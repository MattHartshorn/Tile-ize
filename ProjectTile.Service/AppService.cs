using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using ProjectTile.Common;

namespace ProjectTile.Service
{
    internal class AppService
    {
        #region Private Fields
        private AppServiceConnection _connection;
        private ManualResetEvent _terminate;
        #endregion

        #region Constructor
        public AppService()
        {
            this._terminate = new ManualResetEvent(false);

            this._connection = new AppServiceConnection()
            {
                AppServiceName = "CommunicationService",
                PackageFamilyName = Windows.ApplicationModel.Package.Current.Id.FamilyName,
            };
            this._connection.RequestReceived += OnRequestReceived;
            this._connection.ServiceClosed += OnServiceClosed;
        }
        #endregion

        #region Public Methods
        public void Start()
        {
            OpenConnection();

            this._terminate.WaitOne();
            Console.WriteLine("Terminated");
        }
        #endregion

        #region Private Methods

        private async void OpenConnection()
        {
            var result = await this._connection.OpenAsync();

            // Failed to open the connection
            if (result != AppServiceConnectionStatus.Success)
                this._terminate.Set();
        }
         
        private void ProcessRequest(string command, AppServiceRequest request)
        {
            switch(command)
            {
                case CommandNames.Close:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void Close()
        {
            this._terminate.Set();
        }
        #endregion

        #region EventHandler Methods
        private void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            Console.WriteLine("Request");
            var deferral = args.GetDeferral();
            var command = args.Request.Message["command"] as string;

            ProcessRequest(command, args.Request);
            deferral.Complete();
        }

        private void OnServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            this._terminate.Set();
            Console.WriteLine("Closed");
        }
        #endregion
    }
}

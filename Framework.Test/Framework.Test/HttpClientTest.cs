using Framework.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trex.Framework.Controls;
using Trex.Framework.Core.Geolocation;
using Trex.Framework.Core.Serializer;
using Trex.Framework.Core.Web;
using Trex.Framework.Service.Geolocation;
using Xamarin.Forms;

namespace Framework.Test
{
    public class HttpClientTest : ContentPage
    {

        public HttpClientTest()
        {

            this.BindingContext = new pointViewModel(this);
           
            Content = new StackLayout()
            {
                Children =
                {
                    new Button(){
                        Text="get point",
                        Command = ((pointViewModel)(this.BindingContext)).GetPositionCommand
                    },
                  new Label(){
                      Text="test"
                    }
                }
            };
        }
    }

    public class pointViewModel
    {
        private IGeolocator Geolocator;
        private ContentPage _contentpage;
        public pointViewModel(ContentPage contentpage)
        {
            this._contentpage = contentpage;
            Geolocator = DependencyService.Get<IGeolocator>();
        }

        /// </summary>
        private Command _getPositionCommand;

        public Command GetPositionCommand
        {
            get
            {
                return _getPositionCommand ??
                    (_getPositionCommand = new Command(async () => await GetPosition(), () => Geolocator != null));
            }
        }
        private async Task GetPosition()
        {
            var _cancelSource = new CancellationTokenSource();
            TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var PositionStatus = string.Empty;
            var PositionLatitude = string.Empty;
            var PositionLongitude = string.Empty;
            var IsBusy = true;
            await
                Geolocator.GetPositionAsync(10000, _cancelSource.Token, true).ContinueWith(t =>
                    {
                        IsBusy = false;
                        if (t.IsFaulted)
                        {
                            PositionStatus = ((GeolocationException)t.Exception.InnerException).Error.ToString();
                            _contentpage.DisplayAlert("sdf", PositionStatus, "asd");
                        }
                        else if (t.IsCanceled)
                        {
                            _contentpage.DisplayAlert("sdf", "IsCanceled", "asd");
                        }
                        else
                        {
                            PositionLatitude = "La: " + t.Result.Latitude.ToString("N4");
                            PositionLongitude = "Lo: " + t.Result.Longitude.ToString("N4");
                            _contentpage.DisplayAlert("sdf", PositionLatitude + "," + PositionLongitude, "asd");
                        }
                    }, _scheduler);
        }
    }
}

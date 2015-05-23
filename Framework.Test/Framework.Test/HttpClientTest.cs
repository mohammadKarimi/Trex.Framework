using Framework.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trex.Framework.Controls;
using Trex.Framework.Core;
using Trex.Framework.Core.Serializer;
using Trex.Framework.Core.Web;
using Xamarin.Forms;

namespace Framework.Test
{
    public class HttpClientTest : ContentPage
    {
        public HttpClientTest()
        {
            this.BindingContext = new signInViewModel();
            this.Send();

            var TxProgressBar = new TxProgressBar()
            {
                Indeterminate = true
            };

            var DaysOfSyncDataValueSlider = new TxLabel()
            {
                FontFamily = "Byekan",
                HorizontalOptions = LayoutOptionsExtensions.End,
            };
            DaysOfSyncDataValueSlider.SetBinding(Label.TextProperty, new Binding("DaysOfSyncData", BindingMode.OneWay));

            var DaysOfSyncDataSlider = new Slider()
            {
                Maximum = 30,
                Minimum = 1,

            };
            DaysOfSyncDataSlider.SetBinding(Slider.ValueProperty, new Binding("DaysOfSyncData", BindingMode.TwoWay));

            var button = new Button
            {
                Text = "Click Me!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Command = ((signInViewModel)BindingContext).SignInCommand
            };

            Editor Editor = new Editor() { };
            Content = new StackLayout() { Children = {TxProgressBar, DaysOfSyncDataValueSlider, DaysOfSyncDataSlider, button, Editor } };
        }
        private void Send()
        {
            MessagingCenter.Send<NavigationMessage>(new NavigationMessage() { Parameter = this }, NavigationMessageType.Page.ToString());
            MessagingCenter.Send<NavigationMessage>(new NavigationMessage() { Parameter = this.Navigation }, NavigationMessageType.Navigation.ToString());
        }
    }
}

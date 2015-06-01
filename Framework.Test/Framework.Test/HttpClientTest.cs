using Framework.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trex.Framework.Controls;
using Trex.Framework.Core;
using Trex.Framework.Core.DateTime;
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


            var TxProgressBar = new TxProgressBar()
            {
                Indeterminate = true
            };

            
            
            var DaysOfSyncDataValueSlider = new TxLabel()
            {
                FontFamily = "Byekan",
                HorizontalOptions = HorizontalOptionsExtensions.End,
            };

            var mat = new TxIconLabel("\uf1db", TxFontIcons.MaterialDesign)
            {

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
            Content = new StackLayout() { Children = { mat, TxProgressBar, DaysOfSyncDataValueSlider, DaysOfSyncDataSlider, button, Editor } };
        }

    }
}

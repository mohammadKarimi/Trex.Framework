using Framework.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trex.Framework.Controls;
using Xamarin.Forms;

namespace Framework.Test
{
    public class HttpClientTest : ContentPage
    {
        public HttpClientTest()
        {
            this.BindingContext = new signInViewModel();

            Content = new StackLayout()
            {
                Children =
                {
                   // new policyTabbedPage()
                }
            };
        }

    }
}

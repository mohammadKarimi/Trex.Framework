using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trex.Framework.Core.Serializer;
using Trex.Framework.Core.Web;
using Xamarin.Forms;

namespace Framework.Test
{
    public class HttpClientTest : ContentPage
    {
        public HttpClientTest()
        {
            var button = new Button
            {
                Text = "Click Me!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            button.Clicked += async (s, e) =>
            {

                var HttpRestClient = new HttpRestClient(new Serializer());
                //var data = new object();
                //data = new
                //{
                //    username = this.UserName,
                //    password = this.Password
                //};
                var ret = await HttpRestClient.GetAsync<HttpActionResult<int>>("http://localhost:59685/oauth/signIn?username=0453711464&password=2908418021");
                if (ret != null && ret.IsSuccess)
                {
                    // Navigation.Push();
                }
            };

            Content = button;
        }
    }
}

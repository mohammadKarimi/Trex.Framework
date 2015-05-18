using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

            Editor Editor = new Editor() { };

            button.Clicked += async (s, e) =>
            {
                var httpClient = new HttpRestClient(new Serializer()); // Xamarin supports HttpClient!
                var response = await httpClient.PostAsync<HttpActionResult<int>>("http://46.34.96.71/mobileInsurance.api/oauth/signInPost?username=0079445098&password=0079445098"); // async method!
                Editor.Text =   response.Result.ToString();
            };

            Content = new StackLayout() { Children = { button, Editor } };
        }
    }
}

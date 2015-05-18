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
                var HttpRestClient = new HttpRestClient(new Serializer());
                var response = await HttpRestClient.GetAsync<HttpActionResult<Accounts>>("http://46.34.96.71/mobileInsurance.api/person/getpersonprofilebynationalcode",
                    new Dictionary<string, string>() { { "nationalCode", "0079445098" } });
            
                Editor.Text =   response.Result.AccountsId.ToString();
            };

            Content = new StackLayout() { Children = { button, Editor } };
        }
    }
}

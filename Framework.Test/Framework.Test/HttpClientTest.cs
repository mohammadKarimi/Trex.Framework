using Framework.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trex.Framework.Controls;
using Trex.Framework.Core.Serializer;
using Trex.Framework.Core.Web;
using Xamarin.Forms;

namespace Framework.Test
{
    public class HttpClientTest : ContentPage
    {
        public HttpClientTest()
        {
            string result = "test";
            try
            {
                var res = this.web();
                DisplayAlert("asdf"," res.Result.ToString()", "sdaf");

            }
            catch (Exception e)
            {
                DisplayAlert("asdf", e.Message + "  ::: " + e.StackTrace, "sdaf");
            }
            Content = new StackLayout()
            {
                Children =
                {
                  new Label(){
                      Text=result
                    }
                }
            };
        }

        private async Task<string> web()
        {
            IRestClient http = new HttpRestClient(new Serializer());
            var response = await http.PostAsync<HttpActionResult<int>>("http://46.34.96.71/mobileInsurance.api/OAuth/SignIn", new
            {
                username = "0079445098",
                password = "0079445098"
            });

            if (response != null && response.IsSuccess)
            {
                return "true";
            }
            return "false";
        }
    }
}

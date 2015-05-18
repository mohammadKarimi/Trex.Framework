using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Framework.Test
{
    public class App : Application
    {
        public App()
        {
            MainPage = new HttpClientTest();
        }

    }
}

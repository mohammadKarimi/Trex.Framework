using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Framework.Test
{
    public class LossCrousel : CarouselPage 
    {
        public LossCrousel()
        {
            this.Children.Add(new BluePage());
            this.Children.Add(new RedPage());
            this.Children.Add(new YellowPage());
        }
    }
    public class BluePage : ContentPage
    {
        public BluePage()
        {
            BackgroundColor = Color.Blue;
        }
    }

    // Red Page
    public class RedPage : ContentPage
    {
        public RedPage()
        {
            BackgroundColor = Color.Red;
        }
    }

    // Yellow Page
    public class YellowPage : ContentPage
    {
        public YellowPage()
        {
            BackgroundColor = Color.Yellow;
        }
    }

}

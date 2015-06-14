namespace Trex.Framework.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xamarin.Forms;

    public delegate void CurrentPageChangingEventHandler();
    public delegate void CurrentPageChangedEventHandler();
    public delegate void SwipeLeftEventHandler();
    public delegate void SwipeRightEventHandler();
    public class TxTabbedPage : TabbedPage
    {
        public static readonly BindableProperty FontProperty = BindableProperty.Create("Font", typeof(Font), typeof(TabbedPage), new Font());
        public Font Font
        {
            get { return (Font)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }

        public static readonly BindableProperty TintColorProperty =
           BindableProperty.Create<TxTabbedPage, Color>(
               p => p.TintColor, Color.White);

        public static readonly BindableProperty BarTintColorProperty =
            BindableProperty.Create<TxTabbedPage, Color>(
                p => p.BarTintColor, Color.White);

        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create<TxTabbedPage, Color>(
                p => p.BackgroundColor, Color.White);

        public static readonly BindableProperty BadgesProperty =
           BindableProperty.Create<TxTabbedPage, List<string>>(
               p => p.Badges, null);

        public static readonly BindableProperty TabBarSelectedImageProperty =
            BindableProperty.Create<TxTabbedPage, string>(
                p => p.TabBarSelectedImage, null);

        public static readonly BindableProperty TabBarBackgroundImageProperty =
            BindableProperty.Create<TxTabbedPage, string>(
                p => p.TabBarBackgroundImage, null);

        public Color TintColor
        {
            get
            {
                return (Color)GetValue(TintColorProperty);
            }
            set
            {
                SetValue(TintColorProperty, value);
            }
        }
        public Color BarTintColor
        {
            get
            {
                return (Color)GetValue(BarTintColorProperty);
            }
            set
            {
                SetValue(BarTintColorProperty, value);
            }
        }
        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }
        public List<string> Badges
        {
            get
            {
                return (List<string>)GetValue(BadgesProperty);
            }
            set
            {
                SetValue(BadgesProperty, value);
            }
        }
        public string TabBarSelectedImage
        {
            get
            {
                return (string)GetValue(TabBarSelectedImageProperty);
            }
            set
            {
                SetValue(TabBarSelectedImageProperty, value);
            }
        }
        public string TabBarBackgroundImage
        {
            get
            {
                return (string)GetValue(TabBarBackgroundImageProperty);
            }
            set
            {
                SetValue(TabBarBackgroundImageProperty, value);
            }
        }
        public bool SwipeEnabled;
        public TxTabbedPage()
        {
            PropertyChanging += OnPropertyChanging;
            PropertyChanged += OnPropertyChanged;
            OnSwipeLeft += SwipeLeft;
            OnSwipeRight += SwipeRight;
            SwipeEnabled = false;
            Badges = new List<string>();
        }
        public event CurrentPageChangingEventHandler CurrentPageChanging;
        public event CurrentPageChangedEventHandler CurrentPageChanged;
        public event EventHandler OnSwipeRight;
        public event EventHandler OnSwipeLeft;
        public void InvokeSwipeRightEvent(object sender, object item)
        {
            if (OnSwipeRight != null)
            {
                OnSwipeRight.Invoke(sender, new EventArgs());
            }
        }
        public void InvokeSwipeLeftEvent(object sender, object item)
        {
            if (OnSwipeLeft != null)
            {
                OnSwipeLeft.Invoke(sender, new EventArgs());
            }
        }
        private void OnPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == "CurrentPage")
            {
                RaiseCurrentPageChanging();
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentPage")
            {
                RaiseCurrentPageChanged();
            }
        }
        private void SwipeLeft(object a, EventArgs e)
        {
            if (SwipeEnabled)
            {
                PreviousPage();
            }
        }
        private void SwipeRight(object a, EventArgs e)
        {
            if (SwipeEnabled)
            {
                NextPage();
            }
        }
        private void RaiseCurrentPageChanging()
        {
            var handler = CurrentPageChanging;

            if (handler != null)
            {
                handler();
            }
        }
        private void RaiseCurrentPageChanged()
        {
            var handler = CurrentPageChanged;

            if (handler != null)
            {
                handler();
            }
        }
        private void NextPage()
        {
            var currentPage = Children.IndexOf(CurrentPage);

            currentPage++;

            if (currentPage > Children.Count - 1)
            {
                currentPage = 0;
            }

            CurrentPage = Children[currentPage];
        }
        private void PreviousPage()
        {
            var currentPage = Children.IndexOf(CurrentPage);

            currentPage--;

            if (currentPage < 0)
            {
                currentPage = Children.Count - 1;
            }

            CurrentPage = Children[currentPage];
        }
    }
}

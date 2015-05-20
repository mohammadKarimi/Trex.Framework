namespace Trex.Framework.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            this.Subscribe();
        }
        protected INavigation Navigation { get; set; }
        protected Page Page { get; set; }

        protected void Subscribe()
        {
            MessagingCenter.Subscribe<NavigationMessage>(this, NavigationMessageType.Page.ToString(), (page) =>
            {
                this.Page = (Page)page.Parameter;
            });
            MessagingCenter.Subscribe<NavigationMessage>(this, NavigationMessageType.Navigation.ToString(), (navigation) =>
            {
                this.Navigation = (INavigation)navigation.Parameter;
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public enum NavigationMessageType
    {
        Page,
        Navigation
    }
}

namespace Trex.Framework.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ViewModelNavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
